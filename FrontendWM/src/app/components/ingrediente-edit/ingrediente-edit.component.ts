import { Component, OnInit } from '@angular/core';
import { Ingrediente } from 'src/app/models/ingrediente';
import { IngredienteService } from 'src/app/services/ingrediente.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-ingrediente-edit',
  templateUrl: './ingrediente-edit.component.html',
  template: `
    <p>Editar Ingrediente con ID: {{ ingredienteId }}</p>
  `,
  styleUrls: ['./ingrediente-edit.component.css']
})
export class IngredienteEditComponent implements OnInit {
  ingredienteId: number | undefined;
  ingrediente: Ingrediente = { id: 0, nombre: '', caloriasX100mg: 0, fibraX100mg: 0, potasioX100mg: 0,
  tieneYodo: false, tieneCalcio: false, linkFoto: "" };

  constructor(private ingredienteService: IngredienteService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.ingredienteId = +params['id'];
    });

    this.ingredienteService.getIngrediente(this.ingredienteId).subscribe((data: Ingrediente) => {
      this.ingrediente = data;
      console.log(data)
    });
  }

  onSubmit() {
    this.ingredienteService.editIngrediente(this.ingrediente).subscribe(
      (response) => {
        console.log('Ingrediente editado:', response);
        this.redirectList();
      },
      (error) => {
        console.error('Error al editar el ingrediente:', error);
      }
    )
  }  
  
  redirectList() {
    this.router.navigate(['ingrediente']);
  }
}
