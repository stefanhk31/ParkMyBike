import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateBikerackModalComponent } from './create-bikerack-modal.component';

describe('CreateBikerackModalComponent', () => {
  let component: CreateBikerackModalComponent;
  let fixture: ComponentFixture<CreateBikerackModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateBikerackModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateBikerackModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
