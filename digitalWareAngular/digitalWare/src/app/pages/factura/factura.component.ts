import { ChangeDetectorRef } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import CustomStore from 'devextreme/data/custom_store';
import notify from 'devextreme/ui/notify';
import { Subscription } from 'rxjs';
import { cliente } from 'src/app/models/cliente';
import { factura } from 'src/app/models/factura';
import { producto } from 'src/app/models/Producto';
import { productoFactura } from 'src/app/models/productoFactura';
import { vendedor } from 'src/app/models/vendedor';
import { ClienteService } from 'src/app/services/cliente.service';
import { FacturaService } from 'src/app/services/factura.service';
import { ProductoService } from 'src/app/services/producto.service';
import { VendedorService } from 'src/app/services/vendedor.service';

@Component({
  selector: 'app-factura',
  templateUrl: './factura.component.html',
  styleUrls: ['./factura.component.scss']
})
export class FacturaComponent implements OnInit {

  priority: any[];
  facturas: factura[];
  factura: factura = new factura;
  popupNuevoVisible: Boolean;
  facturasSubcription: Subscription;
  cantidad: number = 1;
  total: number = 0;
  listaProductosCantidad: string;
  productosAgregados: producto[];

  clientes: cliente[];
  clientesList: any;
  gridBoxValueCliente: number[] = [3];
  gridColumnsCliente: any = ['nombre', 'apellido', 'cedula'];
  isGridBoxOpenedCliente: boolean;
  clientesSubcription: Subscription;

  vendedores: vendedor[];
  vendedoresList: any;
  gridBoxValueVendedor: number[] = [3];
  gridColumnsVendedor: any = ['nombre', 'apellido', 'cedula'];
  isGridBoxOpenedVendedor: boolean;
  vendedoresSubcription: Subscription;

  productos: producto[];
  productosList: any;
  productosSeleccionados: any;
  productosSubcription: Subscription;

  gridBoxValueProducto: number[] = [2];
  gridColumnsProducto: any = ['nombre', 'stockMinimo', 'precio'];
  isGridBoxOpenedProducto: boolean;



  constructor(
    private facturaService: FacturaService,
    private clienteService: ClienteService,
    private vendedorService: VendedorService,
    private productoService: ProductoService,

    private ref: ChangeDetectorRef
  ) {
    this.popupNuevoVisible = false;
    this.facturas = new Array<factura>();
    this.productos = new Array<producto>();
    this.productosAgregados = new Array<producto>();

    this.isGridBoxOpenedProducto = false;
    this.isGridBoxOpenedCliente = false;
    this.isGridBoxOpenedVendedor = false;

    this.listaProductosCantidad = "";

    this.productosList = this.makeDataSource("productos");
    this.vendedoresList = this.makeDataSource("vendedores");
    this.clientesList = this.makeDataSource("clientes");
  }
  ngOnInit(): void {
    //this.obtenerLista();
    this.obtenerProductos();
  }

  obtenerLista() {
    if (this.facturasSubcription) {
      this.facturasSubcription.unsubscribe();
    }
    this.facturasSubcription = this.facturaService.ObtenerLista().subscribe(
      (res: factura[]) => {
        this.facturas = res;
      }
    );
  }

  modalNuevo() {
    this.popupNuevoVisible = true;
  }

  logSubmit(e) {
    e.preventDefault();
    console.log("factura", this.factura)
    this.cerrarModal();
    this.crear(this.factura);

  }

  cerrarModal() {
    this.popupNuevoVisible = !this.popupNuevoVisible;
  }

  crear(factura: factura) {
    this.facturaService.Crear(factura).subscribe(
      res => {
        console.log("factura creado corectamente", res);
        this.obtenerLista();
        this.notificacion("factura creado correctamente", "success")
      }, error => {
        console.error("Algo salio mal", error)
      }
    );
  }

  notificacion(text, type) {
    notify(text, type, 1000);
  }

  //---------------- Facuras -------------------
  obtenerClientes() {
    if (this.clientesSubcription) {
      this.clientesSubcription.unsubscribe();
    }
    this.clientesSubcription = this.clienteService.ObtenerLista().subscribe(
      (res: cliente[]) => {
        this.clientes = res;
      }
    );
  }

  obtenerProductos() {
    if (this.productosSubcription) {
      this.productosSubcription.unsubscribe();
    }
    this.productosSubcription = this.productoService.ObtenerLista().subscribe(
      (res: producto[]) => {
        this.productos = res;
      }
    );
  }

  obtenerVendedores() {
    if (this.vendedoresSubcription) {
      this.vendedoresSubcription.unsubscribe();
    }
    this.vendedoresSubcription = this.vendedorService.ObtenerLista().subscribe(
      (res: vendedor[]) => {
        this.vendedores = res;
      }
    );
  }


  //-----------------------------------

  agregarProducto() {
    console.log("Producto agregado", this.gridBoxValueProducto[0]);
    var item = this.productos.find(x => x.id == this.gridBoxValueProducto[0]);

    this.productosAgregados.push(item);

    this.total = this.total + item.precio;

    this.listaProductosCantidad += (item.nombre + ": " + this.cantidad + "  -  ");

    //reinicio contadores
    this.cantidad = 1;
  }

  agregarFactura() {
    this.factura.total = this.total;
    this.factura.vendedorId = this.gridBoxValueVendedor[0];

    var listaProductoFactura: productoFactura[] = new Array<productoFactura>();

    this.productosAgregados.forEach(element => {
      var res = new productoFactura();
      res.productoId = element.id;
      listaProductoFactura.push(res);
    });

    this.factura.productosFacturas = listaProductoFactura;

    //reinicio contadores
    this.total = 0;
    this.cantidad = 1;
    this.listaProductosCantidad = "";
    listaProductoFactura =  new Array<productoFactura>();

    this.crear(this.factura);
  }


  makeDataSource(type: string) {
    var _this = this;
    return new CustomStore({
      loadMode: "raw",
      key: "id",
      load: function () {
        switch (type) {
          case "productos":
            return _this.productoService.ObtenerLista().toPromise();
            break;
          case "vendedores":
            return _this.vendedorService.ObtenerLista().toPromise();
            break;
          case "clientes":
            return _this.clienteService.ObtenerLista().toPromise();
            break;
          case "vendedores":
            return _this.vendedorService.ObtenerLista().toPromise();
            break;
          default:
            break;
        }

      }
    });
  };

  gridBox_displayExpr(item) {
    console.log("item", item);
    return item?.nombre + " - Disponibles: " + item?.id;
  }
  onGridBoxOptionChanged(e, type: string) {
    if (e.name === "value") {
      switch (type) {
        case "clientes":
          this.isGridBoxOpenedCliente = false;
          break;
        case "productos":
          this.isGridBoxOpenedProducto = false;
          break;

        case "vendedores":
          this.isGridBoxOpenedVendedor = false;
          break;
        default:
          break;
      }
      this.ref.detectChanges();
    }
  }


}
