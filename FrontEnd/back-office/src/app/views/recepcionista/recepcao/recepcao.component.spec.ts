import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecepcaoComponent } from './recepcao.component';

describe('RecepcaoComponent', () => {
  let component: RecepcaoComponent;
  let fixture: ComponentFixture<RecepcaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecepcaoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RecepcaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
