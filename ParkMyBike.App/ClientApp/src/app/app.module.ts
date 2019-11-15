import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BikeracksComponent } from './bikeracks/bikeracks.component';
import { BikeRacksService } from './services/bikeracks.service';

@NgModule({
  declarations: [
    AppComponent,
    BikeracksComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule
  ],
  providers: [
    BikeRacksService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
