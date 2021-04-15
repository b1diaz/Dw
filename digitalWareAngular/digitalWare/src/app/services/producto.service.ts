import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { producto } from '../models/Producto';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  baseUrl: string;

  constructor(private http: HttpClient) {
    this.baseUrl = environment.urlApi + "/Producto";
  }

  ObtenerLista(): Observable<producto[]> {
    return this.http.get<producto[]>(this.baseUrl + "/productos")
  }

  Obtener(productoId: number): Observable<producto> {
    return this.http.get<producto>(this.baseUrl + "/producto/"+ productoId)
  }

  Crear(producto: producto) {
    return this.http.post<producto>(this.baseUrl+"/crear", producto);
  }

  Actualizar(producto: producto) {
    return this.http.put<producto>(this.baseUrl+"/actualizar", producto);
  }

  Eliminar(productoId: number) {
    return this.http.delete<producto>(this.baseUrl+"/eliminar/"+productoId.toString());
  }
}
