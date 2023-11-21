import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Ingrediente } from '../models/ingrediente';

@Injectable({
  providedIn: 'root'
})
export class IngredienteService {

  private apiUrl = 'https://localhost:44309/api/Ingrediente/'; 

  constructor(private http: HttpClient) { }

  getIngredientes(): Observable<Ingrediente[]>  {
    const url = `${this.apiUrl}` + 'GetIngredientes' ;
    return this.http.get<Ingrediente[]>(url);
  }

  getIngrediente(id?: number): Observable<Ingrediente>  {
    const url = `${this.apiUrl}GetIngrediente?id=${id}` ;
    return this.http.get<Ingrediente>(url);
  }

  addIngrediente(ingrediente: Ingrediente): Observable<Ingrediente>  {
    const url = `${this.apiUrl}` + 'Create' ;
    return this.http.post<Ingrediente>(url,ingrediente);
  }

  editIngrediente(ingrediente: Ingrediente): Observable<Ingrediente>  {
    const url = `${this.apiUrl}` + 'Edit' ;
    return this.http.put<Ingrediente>(url,ingrediente);
  }

  deleteIngrediente(id?: number): Observable<any>  {
    const url = `${this.apiUrl}Delete?id=${id}` ;
    return this.http.delete(url);
  }
}
