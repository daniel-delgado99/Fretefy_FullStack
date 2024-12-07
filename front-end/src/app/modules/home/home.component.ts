import { Component, OnInit } from '@angular/core';
import { RegiaoService } from '../../services/regiao.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  regioes: any[];

  constructor(private regiaoService: RegiaoService, private router: Router) { }

  ngOnInit(): void {
    this.regioes = this.regiaoService.getRegioes();
  }

  formatarCidades(cidades: any) {
    return cidades.length > 0 ? cidades.map(c => `${c.nome} - ${c.uf}`).join(', ') : '';
  }

  removerRegiao(regiao: any) {
    if (confirm(`Tem certeza que deseja remover a região ${regiao.nome}?`)) {
      this.regiaoService.removerRegiaoById(regiao.id)
    }
  }

  toggleAtiva(regiao) {
    this.regiaoService.toggleAtiva(regiao.id)
  }

  editarRegiao(regiao: any) {
    this.router.navigate(['/regiao/' + regiao.id])
  }

  irParaCadastro() {
    this.router.navigate(['/regiao'])
  }

  exportarParaExcel() {
    const regioes = this.regiaoService.getRegioes();
    if (!regioes || regioes.length === 0) {
      alert('Não há regiões para exportar!');
      return;
    }

    let csvContent = 'ID,Região,Cidades,Status\n';

    regioes.forEach(regiao => {
      csvContent += `"${regiao.id}","${regiao.nome}","${this.formatarCidades(regiao.cidades)}","${regiao.ativo ? 'Ativa' : 'Desativada'}"\n`;
    });

    const blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' });
    const url = URL.createObjectURL(blob);

    const a = document.createElement('a');
    a.href = url;
    a.download = 'regioes.csv';
    a.style.display = 'none';

    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
  }
}
