import { FormGroup } from '@angular/forms';
import { BikeRack } from '../interfaces/bikerack.interface';

export class ReactiveFormsHelpers {
    public static mapFormValueToBikeRackType(form: FormGroup, rack: BikeRack): void {
        rack.numberOfRacks = form.value["NumberOfRacks"];
        rack.latLong = form.value["LatLong"];
        rack.locationDescription = form.value["LocationDescription"];
        rack.status = form.value["Status"];
        rack.rackType = form.value["RackType"];
      }
}