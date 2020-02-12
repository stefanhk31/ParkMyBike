import { BikeRack } from '../interfaces/bikerack.interface';
import { Observable } from 'rxjs';
import mockBikeRacks from '../resources/testResources';

export class MockBikeRacksService {
    public bikeRacks: BikeRack[];
    
    loadBikeRacks() {
      return Observable.create((observer) => {
        observer.next(mockBikeRacks);
        this.bikeRacks = mockBikeRacks;
      });
    } 
}