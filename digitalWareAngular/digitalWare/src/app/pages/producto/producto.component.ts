import { Component, OnInit } from '@angular/core';
import notify from 'devextreme/ui/notify';
import { Subscription } from 'rxjs';
import { producto } from 'src/app/models/Producto';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-producto',
  templateUrl: './producto.component.html',
  styleUrls: ['./producto.component.scss']
})
export class ProductoComponent implements OnInit {

  productos: producto[];
  producto: producto = new producto;
  popupNuevoVisible: Boolean;
  productosSubcription: Subscription;

  constructor(private productoService: ProductoService) {
    this.popupNuevoVisible = false;
    this.productos = new Array<producto>();
  }
  ngOnInit(): void {
    this.obtenerLista();
  }

  obtenerLista() {
    if (this.productosSubcription) {
      this.productosSubcription.unsubscribe();
    }
    this.productosSubcription = this.productoService.ObtenerLista().subscribe(
      (res: producto[]) => {
        this.productos = res;
      }
    );
  }

  modalNuevo() {
    this.popupNuevoVisible = true;
  }

  logSubmit(e) {
    e.preventDefault();
    console.log("producto", this.producto)
    this.cerrarModal();
    this.crearCliente(this.producto);

  }

  cerrarModal() {
    this.popupNuevoVisible = !this.popupNuevoVisible;
  }

  crearCliente(producto: producto) {
    this.productoService.Crear(producto).subscribe(
      res => {
        console.log("producto creado corectamente", res);
        this.obtenerLista();
        this.notificacion("producto creado correctamente", "success")
      }, error => {
        console.error("Algo salio mal", error)
      }
    );
  }

  notificacion(text, type) {
    notify(text, type, 1000);
  }
}
