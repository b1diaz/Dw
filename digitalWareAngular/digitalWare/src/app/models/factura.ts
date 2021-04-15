import { claseBase } from "./claseBase";
import { cliente } from "./cliente";
import { productoFactura } from "./productoFactura";
import { vendedor } from "./vendedor";

export class factura extends claseBase {
    total: number;
    vendedorId: number;
    vendedor: vendedor;
    productosFacturas: productoFactura[];
    clienteId: number;
    cliente: cliente;
}
