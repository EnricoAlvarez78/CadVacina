import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecepcionistaExibeComponent } from './recepcionista-exibe.component';

describe('RecepcionistaExibeComponent', () => {
  let component: RecepcionistaExibeComponent;
  let fixture: ComponentFixture<RecepcionistaExibeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecepcionistaExibeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecepcionistaExibeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
