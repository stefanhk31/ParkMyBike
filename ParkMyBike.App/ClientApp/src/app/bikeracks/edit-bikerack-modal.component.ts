import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { Statuses, RackTypes } from '../resources/enums';
import { BikeRack } from '../interfaces/bikerack.interface';
import { BikeRacksService } from '../services/bikeracks.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { finalize } from 'rxjs/operators';
import { ReactiveFormsHelpers } from '../resources/reactiveFormsHelpers';

@Component({
  selector: 'edit-bikerack-modal',
  templateUrl: './edit-bikerack-modal.component.html',
  styleUrls: ['./edit-bikerack-modal.component.scss']
})
export class EditBikerackModalComponent implements OnInit {
  @ViewChild('editBikeRackModal', { static: true }) modal: ModalDirective;
  @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

  statuses: string[] = Object.values(Statuses).filter((x => isNaN(Number(x)))) as string[];
  types: string[] = Object.values(RackTypes).filter((x => isNaN(Number(x)))) as string[];

  bikeRack: BikeRack = {
    rackId: null,
    numberOfRacks: null,
    latLong: null,
    locationDescription: null,
    status: null,
    rackType: null
  };
  
  active = false;
  saving = false;

  editBikeRackForm: FormGroup;

  constructor(
    private bikeRacksService: BikeRacksService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.editBikeRackForm = this.formBuilder.group({
      NumberOfRacks: [],
      LatLong: [],
      LocationDescription: [],
      Status: [],
      RackType: []
    }, { updateOn: 'blur' })
  }

  show(rackId: number): void {
    this.bikeRacksService.getBikeRackForEdit(rackId).subscribe(success => {
      if (success) {
        this.bikeRack = this.bikeRacksService.bikeRack as BikeRack;
        this.editBikeRackForm.patchValue({
          NumberOfRacks: this.bikeRack.numberOfRacks,
          LatLong: this.bikeRack.latLong,
          LocationDescription: this.bikeRack.locationDescription,
          Status: this.bikeRack.status,
          RackType: this.bikeRack.rackType
        });
      }
      this.active = true;
      this.modal.show();
    });
  }

  save(): void {
    this.saving = true;
    ReactiveFormsHelpers.mapFormValueToBikeRackType(this.editBikeRackForm, this.bikeRack);
    this.bikeRacksService.updateBikeRack(this.bikeRack)
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
