import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecepcionistaFormComponent } from './recepcionista-form.component';

describe('RecepcionistaFormComponent', () => {
  let component: RecepcionistaFormComponent;
  let fixture: ComponentFixture<RecepcionistaFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecepcionistaFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecepcionistaFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
