import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { factura } from '../models/factura';

@Injectable({
  providedIn: 'root'
})
export class FacturaService {


  baseUrl: string;
  listResources: factura[];

  constructor(private http: HttpClient) {
    this.baseUrl = environment.urlApi + "/Factura";
  }

  ObtenerLista(): Observable<factura[]> {
    return this.http.get<factura[]>(this.baseUrl + "/facturas")
  }

  Obtener(facturaId: number): Observable<factura> {
    return this.http.get<factura>(this.baseUrl + "/factura/" + facturaId)
  }

  Crear(factura: factura) {
    return this.http.post<factura>(this.baseUrl + "/crear", factura);
  }

  Actualizar(factura: factura) {
    return this.http.put<factura>(this.baseUrl + "/actualizar", factura);
  }

  Eliminar(facturaId: number) {
    return this.http.delete<factura>(this.baseUrl + "/eliminar/" + facturaId.toString());
  }

}
