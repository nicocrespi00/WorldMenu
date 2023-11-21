import { Component, OnInit } from '@angular/core';
import { Ingrediente } from 'src/app/models/ingrediente';
import { IngredienteService } from 'src/app/services/ingrediente.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ingrediente-add',
  templateUrl: './ingrediente-add.component.html',
  styleUrls: ['./ingrediente-add.component.css']
})
export class IngredienteAddComponent implements OnInit {

  ingrediente: Ingrediente = { id: 0, nombre: '', caloriasX100mg: 0, fibraX100mg: 0, potasioX100mg: 0,
                              tieneYodo: false, tieneCalcio: false, linkFoto: "" };

  constructor(private ingredienteService: IngredienteService, private router: Router) { }

  ngOnInit(): void {

  }

  onSubmit() {
    this.ingredienteService.addIngrediente(this.ingrediente).subscribe(
      (response) => {
        console.log('Ingrediente creado:', response);
        this.redirectList();
      },
      (error) => {
        console.error('Error al crear el ingrediente:', error);
      }
    )
  }  
  
  redirectList() {
    this.router.navigate(['ingrediente']);
  }
}
