import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Shipment } from '../model/shipment';

@Injectable({
  providedIn: 'root'
})
export class ShipmentService {

  private baseUrl = 'https://localhost:5001/api/shipments'

  constructor(private httpClient: HttpClient) { }

  getShipmentList(): Observable<Shipment[]> {
    return this.httpClient.get<Shipment[]>(this.baseUrl);
  } 
}
