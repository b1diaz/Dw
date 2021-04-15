import { factura } from "./factura";
import { producto } from "./Producto";

export class productoFactura {
    /**Fecha de creacion */
    creado: Date | string;
    /**Fecha de Actualizacion */
    actualizado: Date | string;
    productoId: number;
    producto: producto;
    facturaId: number;
    factura: factura;
}