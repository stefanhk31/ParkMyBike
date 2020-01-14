import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BikeRacksComponent } from './bikeRacks.component';

describe('BikeRacksComponent', () => {
  let component: BikeRacksComponent;
  let fixture: ComponentFixture<BikeRacksComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BikeRacksComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BikeRacksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });
});
