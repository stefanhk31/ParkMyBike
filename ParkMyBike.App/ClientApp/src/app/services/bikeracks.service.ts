import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable } from "rxjs";
import { map, catchError } from 'rxjs/operators';
import { BikeRack } from '../interfaces/bikerack.interface';


@Injectable()
export class BikeRacksService {
  //TODO: this url only works for dev, needs to be configured to change on prod build
  private apiUrl: string = "http://localhost:53203";
  private httpOptions = {
    'headers': {'Content-Type': 'application/json'}
  };

  constructor(private http: HttpClient) {
  }
  
  public bikeRacks: BikeRack[] = [];
  public bikeRack: BikeRack;

   loadBikeRacks(): Observable<boolean> {
    return this.http.get(this.apiUrl + "/api/bikeRacks")
    .pipe(
      map(
        (data: any[]) => {
          this.bikeRacks = data;
          return true;
        }
      ), 
      catchError(this.handleError<boolean>('loadBikeRacks')));
  }

  addBikeRack(rack: BikeRack): Observable<boolean> {
    return this.http.post(this.apiUrl + "/api/bikeRacks/", rack)
    .pipe(map(() => true));
  }

  getBikeRackForEdit(rackId: number): Observable<boolean> {
    return this.http.get(this.apiUrl + `/api/bikeRacks/${rackId}`)
    .pipe(
      map(
        (data: any) => {
          this.bikeRack = data;
          return true;
        }
      )
    )
  }

  updateBikeRack(rack: BikeRack): Observable<boolean> {
    return this.http.put(this.apiUrl + `/api/bikeRacks/${rack.rackId}`, rack)
    .pipe(map(() => true));
  }

  deleteBikeRack(rackId: number): Observable<boolean> {
    return this.http.delete(this.apiUrl + `/api/bikeRacks/${rackId}`, this.httpOptions)
    .pipe(map(() => true));
  }

  handleError<T> (operation: string) {
    return (error: HttpErrorResponse): Observable<T> => {
      const message = (error.error instanceof ErrorEvent) ? error.error.message : `server returned code ${error.status} with body "${error.error}"`;
      throw new Error(`${operation} failed: ${message}`);
    }
  }
}