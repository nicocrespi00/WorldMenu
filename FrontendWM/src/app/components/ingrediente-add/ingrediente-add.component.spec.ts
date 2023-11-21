import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IngredienteAddComponent } from './ingrediente-add.component';

describe('IngredienteAddComponent', () => {
  let component: IngredienteAddComponent;
  let fixture: ComponentFixture<IngredienteAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IngredienteAddComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IngredienteAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
