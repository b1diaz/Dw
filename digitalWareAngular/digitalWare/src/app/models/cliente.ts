import { claseBase } from "./claseBase";
import { factura } from "./factura";

export class cliente extends claseBase {
    nombre: string;
    apellido: string;
    edad: number;
    cedula: string;
    fechaUltimaCompra: Date | string;
    /**Dias promedio entre compras */
    frecuenciaCompra: number;
    facturas: factura[];
}