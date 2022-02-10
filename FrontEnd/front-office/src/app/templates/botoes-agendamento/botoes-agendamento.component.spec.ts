import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BotoesAgendamentoComponent } from './botoes-agendamento.component';

describe('BotoesAgendamentoComponent', () => {
  let component: BotoesAgendamentoComponent;
  let fixture: ComponentFixture<BotoesAgendamentoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BotoesAgendamentoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BotoesAgendamentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
