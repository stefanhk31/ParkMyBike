import { BikeRacksService } from "./bikeracks.service";
import { BikeRack } from '../interfaces/bikerack.interface';
import { asyncData } from '../resources/asyncObservableHelpers';

describe('BikeRacksService Tests using Spies', () => {
    let httpClientSpy:
    {
        get: jasmine.Spy,
        post: jasmine.Spy,
        put: jasmine.Spy,
        delete: jasmine.Spy
    };
let bikeRacksService: BikeRacksService;
let mockBikeRack: BikeRack;
let mockBikeRacks: BikeRack[];

beforeEach(() => {
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['get', 'post', 'put', 'delete']);
    bikeRacksService = new BikeRacksService(<any>httpClientSpy);
    mockBikeRack = {
        rackId: 0,
        numberOfRacks: 0,
        latLong: '',
        locationDescription: '',
        status: '',
        rackType: ''
    };
    mockBikeRacks = [
        {
            rackId: 0,
            numberOfRacks: 0,
            latLong: '',
            locationDescription: '',
            status: '',
            rackType: ''
        },
        {
            rackId: 0,
            numberOfRacks: 0,
            latLong: '',
            locationDescription: '',
            status: '',
            rackType: ''
        }
    ];
});

it('loadBikeRacks should make a successful http get call', () => {
    const expectedBikeRacks = mockBikeRacks;

    httpClientSpy.get.and.returnValue(asyncData(expectedBikeRacks));

    bikeRacksService.loadBikeRacks().subscribe(
        racks => expect(racks).toBeTruthy(),
        fail
    )
    expect(httpClientSpy.get.calls.count()).toBe(1);
});

it('getBikeRackForEdit should make a successful http get call', () => {
    const bikeRackToGet = mockBikeRack;
    httpClientSpy.post.and.returnValue(asyncData(bikeRackToGet));
    httpClientSpy.get.and.returnValue(asyncData(bikeRackToGet));

    bikeRacksService.getBikeRackForEdit(bikeRackToGet.rackId).subscribe(
        rack => expect(rack).toBeTruthy(),
        fail
    )
    expect(httpClientSpy.get.calls.count()).toBe(1)
});

it('addBikeRack should make a successful http post call', () => {
    const newBikeRack = mockBikeRack;

    httpClientSpy.post.and.returnValue(asyncData(newBikeRack));

    bikeRacksService.addBikeRack(newBikeRack).subscribe(
        racks => expect(racks).toBeTruthy(),
        fail
    )
    expect(httpClientSpy.post.calls.count()).toBe(1);
});

it('updateBikeRack should make a successful http put call', () => {
    const bikeRackToBeUpdated = mockBikeRack;
    bikeRackToBeUpdated.rackId = 1;

    httpClientSpy.put.and.returnValue(asyncData(bikeRackToBeUpdated));

    bikeRacksService.updateBikeRack(bikeRackToBeUpdated).subscribe(
        rack => expect(rack).toBeTruthy(),
        fail
    )
    expect(httpClientSpy.put.calls.count()).toBe(1);
});

it('deleteBikeRack should make a sucessful http delete call', () => {
    const bikeRacks = mockBikeRacks;
    const bikeRackToBeDeleted = bikeRacks[1];

    httpClientSpy.delete.and.returnValue(asyncData(bikeRackToBeDeleted));

    bikeRacksService.deleteBikeRack(bikeRackToBeDeleted.rackId).subscribe(
        rack => expect(rack).toBeTruthy(),
        fail
    )
    expect(httpClientSpy.delete.calls.count()).toBe(1);
});
});

