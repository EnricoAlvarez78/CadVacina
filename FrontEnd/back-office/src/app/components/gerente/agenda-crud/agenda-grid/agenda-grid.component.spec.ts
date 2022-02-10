import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgendaGridComponent } from './agenda-grid.component';

describe('AgendaGridComponent', () => {
  let component: AgendaGridComponent;
  let fixture: ComponentFixture<AgendaGridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AgendaGridComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AgendaGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
