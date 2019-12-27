import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { map } from 'rxjs/operators';
import { BikeRack } from '../interfaces/bikerack.interface';


@Injectable()
export class BikeRacksService {
  //TODO: this url only works for dev, needs to be configured to change on prod build
  private apiUrl: string = "http://localhost:53203";

  constructor(private http: HttpClient) {
  }
  
  public bikeRacks: BikeRack[] = [];

  loadBikeRacks(): Observable<boolean> {
    return this.http.get(this.apiUrl + "/api/bikeRacks")
    .pipe(
      map(
        (data: any[]) => {
          this.bikeRacks = data;
          return true;
        }
      ));
  }

  addBikeRack(rack: BikeRack): Observable<boolean> {
    return this.http.post(this.apiUrl + "/api/bikeRacks/", rack)
    .pipe(map(() => true));
  }
}