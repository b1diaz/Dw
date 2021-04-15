import { Component, OnInit } from '@angular/core';
import notify from 'devextreme/ui/notify';
import { Subscription } from 'rxjs/internal/Subscription';
import { vendedor } from 'src/app/models/vendedor';
import { VendedorService } from 'src/app/services/vendedor.service';


@Component({
  selector: 'app-vendedor',
  templateUrl: './vendedor.component.html',
  styleUrls: ['./vendedor.component.scss']
})
export class VendedorComponent implements OnInit {

  priority: any[];
  vendedores: vendedor[];
  vendedor: vendedor = new vendedor;
  popupNuevoVisible: Boolean;
  vendedoresSubcription: Subscription;

  constructor(private vendedorService: VendedorService) {
    this.popupNuevoVisible = false;
    this.vendedores = new Array<vendedor>();
  }
  ngOnInit(): void {
    this.obtenerLista();
  }

  obtenerLista() {
    if (this.vendedoresSubcription) {
      this.vendedoresSubcription.unsubscribe();
    }
    this.vendedoresSubcription = this.vendedorService.ObtenerLista().subscribe(
      (res: vendedor[]) => {
        this.vendedores  = res;
      }
    );
  }

  modalNuevo() {
    this.popupNuevoVisible = true;
  }

  logSubmit(e) {
    e.preventDefault();
    console.log("vendedor", this.vendedor)
    this.cerrarModal();
    this.crearCliente(this.vendedor);

  }

  cerrarModal() {
    this.popupNuevoVisible = !this.popupNuevoVisible;
  }

  crearCliente(vendedor: vendedor) {
    vendedor.cedula = vendedor.cedula.toString();
    this.vendedorService.Crear(vendedor).subscribe(
      res => {
        console.log("vendedor creado corectamente", res);
        this.obtenerLista();
        this.notificacion("vendedor creado correctamente", "success")
      }, error => {
        console.error("Algo salio mal", error)
      }
    );
  }

  notificacion(text, type) {
    notify(text, type, 1000);
  }


}
