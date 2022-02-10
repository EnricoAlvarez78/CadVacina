import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoteGridComponent } from './lote-grid.component';

describe('LoteGridComponent', () => {
  let component: LoteGridComponent;
  let fixture: ComponentFixture<LoteGridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoteGridComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoteGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
