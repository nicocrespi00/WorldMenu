import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IngredienteEditComponent } from './ingrediente-edit.component';

describe('IngredienteEditComponent', () => {
  let component: IngredienteEditComponent;
  let fixture: ComponentFixture<IngredienteEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IngredienteEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IngredienteEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
