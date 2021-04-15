import { Component, ElementRef, OnInit } from '@angular/core';
import 'devextreme/data/odata/store';
import notify from 'devextreme/ui/notify';
import { Subscription } from 'rxjs';
import { cliente } from 'src/app/models/cliente';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  templateUrl: 'tasks.component.html'
})

export class TasksComponent implements OnInit {

  dataSource: any;
  priority: any[];
  clientes: cliente[];
  cliente: cliente = new cliente;
  popupNuevoVisible: Boolean;
  clientesSubcription: Subscription;

  constructor(private clienteService: ClienteService) {
    //constructor() {
    this.popupNuevoVisible = false;
    this.clientes = new Array<cliente>();

    this.dataSource = {
      store: {
        type: 'odata',
        key: 'Task_ID',
        url: 'https://js.devexpress.com/Demos/DevAV/odata/Tasks'
      },
      expand: 'ResponsibleEmployee',
      select: [
        'Task_ID',
        'Task_Subject',
        'Task_Start_Date',
        'Task_Due_Date',
        'Task_Status',
        'Task_Priority',
        'Task_Completion',
        'ResponsibleEmployee/Employee_Full_Name'
      ]
    };
    this.priority = [
      { name: 'High', value: 4 },
      { name: 'Urgent', value: 3 },
      { name: 'Normal', value: 2 },
      { name: 'Low', value: 1 }
    ];
  }
  ngOnInit(): void {
    this.obtenerLista();
  }

  obtenerLista() {
    if (this.clientesSubcription) {
      this.clientesSubcription.unsubscribe();
    }
    this.clientesSubcription = this.clienteService.ObtenerLista().subscribe(
      (res: cliente[]) => {
        this.clientes = res;
      }
    );
  }

  modalNuevo() {
    this.popupNuevoVisible = true;
  }

  logSubmit(e) {
    e.preventDefault();
    console.log("Cliente", this.cliente)
    this.cerrarModal();
    this.crearCliente(this.cliente);

  }

  cerrarModal() {
    this.popupNuevoVisible = !this.popupNuevoVisible;
  }

  crearCliente(cliente: cliente) {
    cliente.cedula = cliente.cedula.toString();
    this.clienteService.Crear(cliente).subscribe(
      res => {
        console.log("Cliente creado corectamente", res);
        this.obtenerLista();
        this.notificacion("Cliente creado correctamente", "success")
      }, error => {
        console.error("Algo salio mal", error)
      }
    );
  }

  notificacion(text, type) {
    notify(text, type, 1000);
  }

}
