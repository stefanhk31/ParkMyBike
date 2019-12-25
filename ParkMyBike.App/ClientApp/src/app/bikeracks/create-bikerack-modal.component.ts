import { Component, OnInit, ViewChild, EventEmitter, Output } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { BikeRack } from '../interfaces/bikerack.interface';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'create-bikerack-modal',
  templateUrl: './create-bikerack-modal.component.html',
  styleUrls: ['./create-bikerack-modal.component.scss']
})
export class CreateBikerackModalComponent implements OnInit {
  @ViewChild('createBikeRackModal', { static: true }) modal: ModalDirective;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  bikeRack: BikeRack = {
    id: 0,
    numberOfRacks: 0,
    latLong: "",
    locationDescription: "",
    status: "",
    rackType: ""
  };

  active = false;
  saving = false;

  newBikeRackForm: FormGroup;

  constructor() { }

  ngOnInit(): void {
  }

  show(): void {
    this.active = true;
    this.modal.show();
  }

  save(): void {
    this.saving = true;
  }

  close(): void {
    this.active = false;
    this.modal.hide();
  }
}
