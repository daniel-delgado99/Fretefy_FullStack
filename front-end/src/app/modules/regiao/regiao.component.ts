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
  cidadesDisponiveis = CIDADES;

  constructor(private fb: FormBuilder, private regiaoService: RegiaoService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.id = params.get('id');
    });

    this.regiaoForm = this.fb.group({
      nome: ['', Validators.required],
      ativo: [false],
      cidades: this.fb.array([])
    });

    if (this.id) {
      const regiao = this.regiaoService.getRegiaoById(this.id);

      this.regiaoForm.patchValue({
        nome: regiao.nome,
        ativo: regiao.ativo,
      })
      for (let i = 0; i < regiao.cidades.length; i++) {
        this.adicionarCidade(regiao.cidades[i])
      }
    } else {
      this.adicionarCidade()
    }
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
      cidades[i] = this.cidadesDisponiveis.find(cidade => cidade.id == cidades[i].id)
    }

    const result = this.regiaoService.salvarRegiao(this.regiaoForm.value, this.id)
    if (!result.success) {
      alert(result.error)
    } else {
      alert('Cadastrado com sucesso!')
      this.regiaoForm.reset();
      this.getCidades().clear();
      this.adicionarCidade();
      this.router.navigate(['/regiao'])
    }
  }
}
