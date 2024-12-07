import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RegiaoService {
  private regioes = [
    {
      id: 1,
      nome: "Região Sudeste",
      ativo: true,
      cidades: [
        { id: 1, nome: "São Paulo", uf: "SP" },
        { id: 2, nome: "Rio de Janeiro", uf: "RJ" },
        { id: 12, nome: "Campinas", uf: "SP" }
      ]
    },
    {
      id: 2,
      nome: "Região Nordeste",
      ativo: false,
      cidades: [
        { id: 3, nome: "Salvador", uf: "BA" },
        { id: 4, nome: "Fortaleza", uf: "CE" },
        { id: 9, nome: "Recife", uf: "PE" }
      ]
    },
    {
      id: 3,
      nome: "Região Sul",
      ativo: true,
      cidades: [
        { id: 7, nome: "Curitiba", uf: "PR" },
        { id: 10, nome: "Porto Alegre", uf: "RS" },
        { id: 40, nome: "Londrina", uf: "PR" }
      ]
    },
    {
      id: 4,
      nome: "Região Norte",
      ativo: true,
      cidades: [
        { id: 8, nome: "Manaus", uf: "AM" },
        { id: 20, nome: "Porto Velho", uf: "RO" },
        { id: 46, nome: "Ananindeua", uf: "PA" }
      ]
    },
    {
      id: 5,
      nome: "Região Centro-Oeste",
      ativo: false,
      cidades: [
        { id: 6, nome: "Brasília", uf: "DF" },
        { id: 22, nome: "Campo Grande", uf: "MS" },
        { id: 32, nome: "Cuiabá", uf: "MT" }
      ]
    },
    {
      id: 6,
      nome: "Região Nordeste 2",
      ativo: true,
      cidades: [
        { id: 17, nome: "Maceió", uf: "AL" },
        { id: 19, nome: "Teresina", uf: "PI" },
        { id: 21, nome: "Natal", uf: "RN" }
      ]
    },
    {
      id: 7,
      nome: "Região Sudeste 2",
      ativo: true,
      cidades: [
        { id: 13, nome: "São Gonçalo", uf: "RJ" },
        { id: 18, nome: "São Bernardo do Campo", uf: "SP" },
        { id: 31, nome: "São José dos Campos", uf: "SP" }
      ]
    },
    {
      id: 8,
      nome: "Região Sul 2",
      ativo: false,
      cidades: [
        { id: 49, nome: "Caxias do Sul", uf: "RS" },
        { id: 23, nome: "São José", uf: "SC" },
        { id: 24, nome: "Jaboatão dos Guararapes", uf: "PE" }
      ]
    },
    {
      id: 9,
      nome: "Região Norte 2",
      ativo: false,
      cidades: [
        { id: 25, nome: "Osasco", uf: "SP" },
        { id: 29, nome: "Sorocaba", uf: "SP" },
        { id: 50, nome: "Uberlândia", uf: "MG" }
      ]
    },
    {
      id: 10,
      nome: "Região Centro-Oeste 2",
      ativo: true,
      cidades: [
        { id: 39, nome: "Juiz de Fora", uf: "MG" },
        { id: 41, nome: "Mauá", uf: "SP" },
        { id: 42, nome: "Bauru", uf: "SP" }
      ]
    }
  ];

  constructor() { }

  salvarRegiao(regiao: any, id = null) {
    if (id) {
      const index = this.regioes.findIndex(regiao => regiao.id == id)
      this.regioes[index] = {
        id,
        ...regiao
      }
    } else {
      let ultimoId = 0
      if (this.regioes.length === 0) {
        ultimoId = 1;
      } else {
        const regiaoExistente = this.regioes.find(r => r.nome.toLowerCase() === regiao.nome.toLowerCase());

        if (regiaoExistente) {
          return { error: 'Já existe uma região com esse nome!', success: false };
        }
        ultimoId = this.regioes[this.regioes.length - 1].id + 1;
      }

      this.regioes.push({
        ...regiao,
        id: ultimoId,
        ativo: true,
      })
    }
    return { success: true }
  }

  removerRegiaoById(id) {
    let index = this.regioes.findIndex(regiao => regiao.id == id);
    this.regioes.splice(index, 1)
  }

  toggleAtiva(id) {
    let index = this.regioes.findIndex(regiao => regiao.id == id);
    this.regioes[index].ativo = !this.regioes[index].ativo;
  }

  getRegioes() {
    return this.regioes;
  }

  getRegiaoById(id) {
    return this.regioes.find(regiao => regiao.id == id);
  }
}
