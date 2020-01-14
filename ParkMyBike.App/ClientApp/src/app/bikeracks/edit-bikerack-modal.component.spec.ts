import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditBikerackModalComponent } from './edit-bikerack-modal.component';

describe('EditBikerackModalComponent', () => {
  let component: EditBikerackModalComponent;
  let fixture: ComponentFixture<EditBikerackModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditBikerackModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditBikerackModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });
});
