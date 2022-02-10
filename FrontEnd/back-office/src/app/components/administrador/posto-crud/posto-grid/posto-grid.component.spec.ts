import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostoGridComponent } from './posto-grid.component';

describe('PostoGridComponent', () => {
  let component: PostoGridComponent;
  let fixture: ComponentFixture<PostoGridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostoGridComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PostoGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
