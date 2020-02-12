import { async, ComponentFixture, TestBed, ComponentFixtureAutoDetect } from '@angular/core/testing';

import { CreateBikerackModalComponent } from './create-bikerack-modal.component';
import { ModalModule } from 'ngx-bootstrap';
import { FormsModule, ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { BikeRacksService } from '../services/bikeracks.service';
import { MockBikeRacksService } from '../services/mockbikeracks.service';

describe('CreateBikerackModalComponent', () => {
  let component: CreateBikerackModalComponent;
  let service: BikeRacksService;
  let fixture: ComponentFixture<CreateBikerackModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ 
        CreateBikerackModalComponent
      ],
      imports: [
        ModalModule.forRoot(),
        FormsModule,
        ReactiveFormsModule
      ],
      providers: [
        FormBuilder,
        { provide: BikeRacksService, useClass: MockBikeRacksService },
        { provide: ComponentFixtureAutoDetect, useValue: true }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateBikerackModalComponent);
    component = fixture.componentInstance;
  });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });
});
