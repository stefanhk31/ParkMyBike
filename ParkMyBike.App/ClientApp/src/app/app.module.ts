import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ModalModule } from "ngx-bootstrap";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BikeRacksComponent } from './bikeracks/bikeracks.component';
import { BikeRacksService } from './services/bikeracks.service';
import { HttpClientModule } from '@angular/common/http';
import { CreateBikerackModalComponent } from './bikeracks/create-bikerack-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    BikeRacksComponent,
    CreateBikerackModalComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ModalModule.forRoot(),
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    BikeRacksService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
