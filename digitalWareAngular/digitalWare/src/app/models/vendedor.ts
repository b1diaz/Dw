import { claseBase } from "./claseBase";
import { factura } from "./factura";


export class vendedor extends claseBase {
    nombre: string;
    apellido: string;
    cedula: string;
    facturas: factura[];
}