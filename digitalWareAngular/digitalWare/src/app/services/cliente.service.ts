import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { cliente } from '../models/cliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  baseUrl: string;
  listResources: cliente[];

  constructor(private http: HttpClient) {
    this.baseUrl = environment.urlApi + "/Cliente";
  }

  ObtenerLista(): Observable<cliente[]> {
    return this.http.get<cliente[]>(this.baseUrl + "/clientes")
  }

  Obtener(clienteId: number): Observable<cliente> {
    return this.http.get<cliente>(this.baseUrl + "/Cliente" + clienteId)
  }

  Crear(cliente: cliente) {
    return this.http.post<cliente>(this.baseUrl + "/crear", cliente);
  }

  Actualizar(cliente: cliente) {
    return this.http.put<cliente>(this.baseUrl + "/actualizar", cliente);
  }

  Eliminar(clienteId: number) {
    return this.http.delete<cliente>(this.baseUrl + "/eliminar/" + clienteId.toString());
  }

}
