import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IngredientesComponent } from './components/ingredientes/ingredientes.component';
import { IngredienteAddComponent } from './components/ingrediente-add/ingrediente-add.component';
import { IngredienteEditComponent } from './components/ingrediente-edit/ingrediente-edit.component';

const routes: Routes = [
  { path: '', component: IngredientesComponent },
  { path: 'ingrediente', component: IngredientesComponent },
  { path: 'ingrediente/Add', component: IngredienteAddComponent },
  { path: 'ingrediente/edit/:id', component: IngredienteEditComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
