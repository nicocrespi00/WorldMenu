import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { IngredientesComponent } from './components/ingredientes/ingredientes.component';
import { IngredienteAddComponent } from './components/ingrediente-add/ingrediente-add.component';
import { FormsModule } from '@angular/forms';
import { IngredienteEditComponent } from './components/ingrediente-edit/ingrediente-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    IngredientesComponent,
    IngredienteAddComponent,
    IngredienteEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'ingrediente', component: IngredientesComponent },
      { path: 'ingrediente/Add', component: IngredientesComponent },
      { path: 'ingrediente/edit/:id', component: IngredienteEditComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
