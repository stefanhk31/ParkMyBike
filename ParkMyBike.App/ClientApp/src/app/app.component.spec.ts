import { TestBed, async } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { BikeRacksComponent } from './bikeracks/bikeracks.component';
import { CreateBikerackModalComponent } from './bikeracks/create-bikerack-modal.component';
import { EditBikerackModalComponent } from './bikeracks/edit-bikerack-modal.component';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { ModalModule } from 'ngx-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { BikeRacksService } from './services/bikeracks.service';

describe('AppComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppComponent,
        BikeRacksComponent,
        CreateBikerackModalComponent,
        EditBikerackModalComponent
      ],
      imports: [
        BrowserModule,
        BrowserAnimationsModule,
        HttpClientModule,
        ModalModule.forRoot(),
        FormsModule,
        ReactiveFormsModule,
        SweetAlert2Module.forRoot(),
      ],
      providers: [
        BikeRacksService
      ]
    }).compileComponents();
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  // it(`should have as title 'ParkMyBike'`, () => {
  //   const fixture = TestBed.createComponent(AppComponent);
  //   const app = fixture.debugElement.componentInstance;
  //   expect(app.title).toEqual('ParkMyBike');
  // });

  // it('should render title in a h1 tag', () => {
  //   const fixture = TestBed.createComponent(AppComponent);
  //   fixture.detectChanges();
  //   const compiled = fixture.debugElement.nativeElement;
  //   expect(compiled.querySelector('h1').textContent).toContain('Welcome to ParkMyBike!');
  // });
});
