import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BikeracksComponent } from './bikeracks.component';

describe('BikeracksComponent', () => {
  let component: BikeracksComponent;
  let fixture: ComponentFixture<BikeracksComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BikeracksComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BikeracksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
