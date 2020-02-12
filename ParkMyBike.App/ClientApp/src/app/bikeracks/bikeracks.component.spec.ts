import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { BikeRacksComponent } from './bikeRacks.component';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { CreateBikerackModalComponent } from './create-bikerack-modal.component';
import { EditBikerackModalComponent } from './edit-bikerack-modal.component';
import { ModalModule } from 'ngx-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BikeRacksService } from '../services/bikeracks.service';
import { MockBikeRacksService } from '../services/mockbikeracks.service';
import mockBikeRacks from '../resources/testResources';

describe('BikeRacksComponent Tests', () => {
  let component: BikeRacksComponent;
  let fixture: ComponentFixture<BikeRacksComponent>;
  let service: BikeRacksService;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        BikeRacksComponent,
        CreateBikerackModalComponent,
        EditBikerackModalComponent
      ],
      imports: [
        SweetAlert2Module.forRoot(),
        ModalModule.forRoot(),
        FormsModule,
        ReactiveFormsModule
      ],
      providers: [
        BikeRacksComponent,
        { provide: BikeRacksService, useClass: MockBikeRacksService }
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BikeRacksComponent);
    service = TestBed.get(BikeRacksService);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('getBikeRacks should call bikeRacksService.loadBikeRacks()', () => {
    spyOn(service, 'loadBikeRacks').and.callThrough();

    component.getBikeRacks();

    expect(service.loadBikeRacks).toHaveBeenCalled();
  });

  it('getBikeRacks should set component bikeracks after fetching data', (async(done) => {
    component.getBikeRacks();

    fixture.whenStable().then(() => {
      expect(component.bikeRacks).toEqual(mockBikeRacks);
      done();
    });
  }));

  it('when loaded, table should contain one row per bike rack', async(done) => {
    component.getBikeRacks();

    fixture.whenStable().then(() => {
      let trs = fixture.nativeElement.querySelectorAll('tr');
      expect(trs.length).toEqual(mockBikeRacks.length);
      done();
    });
  });

  it('add bike rack button triggers a create modal', () => {
    spyOn(component.createBikeRackModal, 'show');

    let button = fixture.nativeElement.querySelector('button.create');
    button.click();

    expect(component.createBikeRackModal.show).toHaveBeenCalled();
  });
});
