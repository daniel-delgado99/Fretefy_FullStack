import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RegiaoService {

  constructor(private http: HttpClient) { }

  salvarRegiao(regiao, id = null) {
    if (!id) {
      return this.http.post('http://localhost:5000/api/regiao', regiao);
    } else {
      return this.http.put('http://localhost:5000/api/regiao/' + id, regiao);
    }
  }

  toggleAtiva(id) {
    return this.http.put('http://localhost:5000/api/regiao/ToggleAtivo/' + id, id);
  }

  getRegioes() {
    return this.http.get('http://localhost:5000/api/regiao/ListWithCities');
  }

  getRegiaoById(id) {
    return this.http.get('http://localhost:5000/api/regiao/ListWithCitiesById/' + id);
  }

  getCidades() {
    return this.http.get('http://localhost:5000/api/cidade');
  }

  removerRegiaoById(id) {
    return this.http.delete('http://localhost:5000/api/regiao/' + id)
  }

}
