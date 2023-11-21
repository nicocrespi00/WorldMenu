import { Component, OnInit } from '@angular/core';
import { Ingrediente } from 'src/app/models/ingrediente';
import { IngredienteService } from 'src/app/services/ingrediente.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ingredientes',
  templateUrl: './ingredientes.component.html',
  styleUrls: ['./ingredientes.component.css']
})
export class IngredientesComponent implements OnInit {
  ingredientes: Ingrediente[] = [];
  constructor(private ingredienteService: IngredienteService, private router: Router) { }

  ngOnInit(): void {
    this.ingredienteService.getIngredientes().subscribe((data: Ingrediente[]) => {
      console.log(data)
      this.ingredientes = data;
    });
  }

  redirectAdd() {
    this.router.navigate(['ingrediente/Add']);
  }

  redirectEdit(id: number) {
    this.router.navigate(['ingrediente/edit', id]);
  }

  delete(id: number) {
    this.ingredienteService.deleteIngrediente(id).subscribe(
      () => {
        console.log('Ingrediente eliminado correctamente');
      },
      (error) => {
        console.error('Error al eliminar el ingrediente:', error);
      }
    );
  }
}
