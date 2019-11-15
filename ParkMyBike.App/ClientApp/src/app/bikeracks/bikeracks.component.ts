import { Component, OnInit } from '@angular/core';
import { BikeRacksService } from '../services/bikeracks.service';

@Component({
  selector: 'bikeracks',
  templateUrl: './bikeracks.component.html',
  styleUrls: ['./bikeracks.component.scss']
})
export class BikeracksComponent implements OnInit {

  constructor(private data: BikeRacksService) { 
      this.bikeRacks = data.racks;
  }

  ngOnInit() {
  }

  public bikeRacks = [];

}
