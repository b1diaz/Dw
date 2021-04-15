import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { vendedor } from '../models/vendedor';

@Injectable({
  providedIn: 'root'
})
export class VendedorService {

  baseUrl: string;
  listResources: vendedor[];

  constructor(private http: HttpClient) {
    this.baseUrl = environment.urlApi + "/Vendedor";
  }

  ObtenerLista(): Observable<vendedor[]> {
    return this.http.get<vendedor[]>(this.baseUrl + "/vendedores")
  }

  Obtener(vendedorId: number): Observable<vendedor> {
    return this.http.get<vendedor>(this.baseUrl + "/vendedor/"+ vendedorId)
  }

  Crear(vendedor: vendedor) {
    return this.http.post<vendedor>(this.baseUrl+"/crear", vendedor);
  }

  Actualizar(vendedor: vendedor) {
    return this.http.put<vendedor>(this.baseUrl+"/actualizar", vendedor);
  }

  Eliminar(vendedorId: number) {
    return this.http.delete<vendedor>(this.baseUrl+"/eliminar/"+vendedorId.toString());
  }

}
