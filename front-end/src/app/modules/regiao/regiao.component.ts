import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RegiaoService } from 'src/app/services/regiao.service';
import { CIDADES } from 'src/app/shared/cidade';
@Component({
  selector: 'app-regiao',
  templateUrl: './regiao.component.html',
  styleUrls: ['./regiao.component.scss']
})
export class RegiaoComponent implements OnInit {
  id: string | null = null;
  regiaoForm: FormGroup;
  cidadesDisponiveis;

  constructor(private fb: FormBuilder, private regiaoService: RegiaoService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.regiaoForm = this.fb.group({
      nome: ['', Validators.required],
      ativo: [false],
      cidades: this.fb.array([])
    });


    this.route.paramMap.subscribe(params => {
      this.id = params.get('id');
    });

    this.regiaoService.getCidades().subscribe(data => {
      this.cidadesDisponiveis = data;

      if (this.id) {
        this.regiaoService.getRegiaoById(this.id).subscribe((data: any) => {
          const regiao = data;

          this.regiaoForm.patchValue({
            nome: regiao.nome,
            ativo: regiao.ativo,
          })
          for (let i = 0; i < regiao.cidades.length; i++) {
            this.adicionarCidade(regiao.cidades[i])
          }
        });
      } else {
        this.adicionarCidade()
      }
    })
  }

  getCidades(): FormArray {
    return this.regiaoForm.get('cidades') as FormArray;
  }

  adicionarCidade(cidade = null): void {
    const cidadeFormGroup = this.fb.group({
      id: [cidade?.['id'] || '', Validators.required],
    });
    this.getCidades().push(cidadeFormGroup);
  }

  removerCidade(i) {
    this.getCidades().removeAt(i)
  }

  onSubmit() {
    if (this.regiaoForm.invalid) {
      alert('Preencha todos os campos corretamente')
      return;
    }

    if (this.regiaoForm.value.cidades.length < 1) {
      alert('Selecione pelo menos uma cidade')
      return;
    }

    let cidades = this.regiaoForm.value.cidades;
    let temDuplicado = false;

    for (let i = 0; i < cidades.length; i++) {
      if (cidades.slice(i + 1).some(item => item.id == cidades[i].id)) {
        temDuplicado = true;
        break;
      }
    }

    if (temDuplicado) {
      alert('Não é possível cadastrar cidades duplicadas');
      return;
    }

    for (let i = 0; i < cidades.length; i++) {
      cidades[i]['cidadeId'] = this.cidadesDisponiveis.find(cidade => cidade.id == cidades[i].id)['id']
    }

    const value = this.regiaoForm.value
    let model = {
      nome: value.nome,
      ativo: true,
      RegiaoCidades: cidades
    }

    this.regiaoService.salvarRegiao(model, this.id).subscribe(data => {
      alert('Salvo com sucesso!')
      this.regiaoForm.reset();
      this.getCidades().clear();
      this.adicionarCidade();
      this.router.navigate(['/regiao'])
    }, error => {
      alert('Ocorreu um erro')
    })
  }
}
