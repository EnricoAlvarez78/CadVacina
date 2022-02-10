import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TituloAgendamentoComponent } from './titulo-agendamento.component';

describe('TituloAgendamentoComponent', () => {
  let component: TituloAgendamentoComponent;
  let fixture: ComponentFixture<TituloAgendamentoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TituloAgendamentoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TituloAgendamentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
