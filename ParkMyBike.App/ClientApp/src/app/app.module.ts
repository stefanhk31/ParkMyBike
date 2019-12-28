import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ModalModule } from "ngx-bootstrap";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BikeRacksComponent } from './bikeracks/bikeracks.component';
import { BikeRacksService } from './services/bikeracks.service';
import { HttpClientModule } from '@angular/common/http';
import { CreateBikerackModalComponent } from './bikeracks/create-bikerack-modal.component';
import { EditBikerackModalComponent } from './bikeracks/edit-bikerack-modal.component';

@NgModule({
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
    SweetAlert2Module.forRoot()
  ],
  providers: [
    BikeRacksService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
