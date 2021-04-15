import { claseBase } from "./claseBase";
import { productoFactura } from "./productoFactura";

export class producto extends claseBase {
    nombre: string;
    precio: number;
    cantidad: number;
    stockMinimo: number;
    productosFacturas: productoFactura[];
}