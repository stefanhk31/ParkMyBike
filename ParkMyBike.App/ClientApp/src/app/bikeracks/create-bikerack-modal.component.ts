import { Component, OnInit, ViewChild, EventEmitter, Output } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { BikeRack } from '../interfaces/bikerack.interface';
import { BikeRacksService } from '../services/bikeracks.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Statuses, RackTypes } from '../resources/enums';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'create-bikerack-modal',
  templateUrl: './create-bikerack-modal.component.html',
  styleUrls: ['./create-bikerack-modal.component.scss']
})
export class CreateBikerackModalComponent implements OnInit {
  @ViewChild('createBikeRackModal', { static: true }) modal: ModalDirective;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  statuses: string[] = Object.values(Statuses).filter((x => isNaN(Number(x)))) as string[];
  types: string[] = Object.values(RackTypes).filter((x => isNaN(Number(x)))) as string[];

  bikeRack: BikeRack = {
    RackId: 0,
    NumberOfRacks: 0,
    LatLong: "",
    LocationDescription: "",
    Status: "",
    RackType: ""
  };

  active = false;
  saving = false;

  newBikeRackForm: FormGroup;

  constructor(
    private bikeRacksService: BikeRacksService,
    private formBuilder: FormBuilder
    ) {}

  ngOnInit(): void {
    this.newBikeRackForm = this.formBuilder.group({
      NumberOfRacks: [],
      LatLong: [],
      LocationDescription: [],
      Status: [],
      RackType: []
    });
  }

  mapFormValueToBikeRackType(form: FormGroup): void {
    this.bikeRack.NumberOfRacks = form.value["NumberOfRacks"];
    this.bikeRack.LatLong = form.value["LatLong"];
    this.bikeRack.LocationDescription = form.value["LocationDescription"];
    this.bikeRack.Status = form.value["Status"];
    this.bikeRack.RackType = form.value["RackType"];
  }

  show(): void {
    this.active = true;
    this.modal.show();
  }

  save(): void {
    this.saving = true;
    this.mapFormValueToBikeRackType(this.newBikeRackForm);
    this.bikeRacksService.addBikeRack(this.bikeRack)
    .pipe(finalize(() => { this.saving = false;}))
    .subscribe(() => {
      this.close();
      this.modalSave.emit(null);
    });
  }

  close(): void {
    this.active = false;
    this.modal.hide();
  }
}
