import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DataVacinacaoComponent } from './data-vacinacao.component';

describe('DataVacinacaoComponent', () => {
  let component: DataVacinacaoComponent;
  let fixture: ComponentFixture<DataVacinacaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DataVacinacaoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DataVacinacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
