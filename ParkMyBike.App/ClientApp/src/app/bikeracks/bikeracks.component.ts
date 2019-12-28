import { Component, OnInit, ViewChild } from '@angular/core';
import { BikeRacksService } from '../services/bikeracks.service';
import { BikeRack } from '../interfaces/bikerack.interface';
import { CreateBikerackModalComponent } from './create-bikerack-modal.component';
import { EditBikerackModalComponent } from './edit-bikerack-modal.component';

@Component({
  selector: 'bikeracks',
  templateUrl: './bikeracks.component.html',
  styleUrls: ['./bikeracks.component.scss']
})
export class BikeRacksComponent implements OnInit {
  @ViewChild('createBikeRackModal', {static: true}) createBikeRackModal: CreateBikerackModalComponent;
  @ViewChild('editBikeRackModal', {static: true}) editBikeRackModal: EditBikerackModalComponent;

  constructor(private bikeRacksService: BikeRacksService) { 
  }

  public bikeRacks: BikeRack[] = [];


  ngOnInit(): void {
    this.getBikeRacks();
  }

  getBikeRacks(): void {
    this.bikeRacksService.loadBikeRacks().subscribe(success => {
      if (success) {
        this.bikeRacks = this.bikeRacksService.bikeRacks;
      }
    });
  }
}
