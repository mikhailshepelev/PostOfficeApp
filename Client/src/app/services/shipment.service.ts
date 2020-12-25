import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { baseUrl } from '../app.constants';
import { Bag } from '../model/bag';
import { Shipment } from '../model/shipment';

@Injectable({
  providedIn: 'root'
})
export class ShipmentService {

  private url = `${baseUrl}/shipments`

  constructor(private httpClient: HttpClient) { }

  getShipmentList(): Observable<Shipment[]> {
    return this.httpClient.get<Shipment[]>(this.url);
  }

  createShipment(shipment: Shipment) {
    return this.httpClient.post(this.url, shipment)
  }

  getShipment(id: number): Observable<Shipment> {
    return this.httpClient.get<Shipment>(`${this.url}/${id}`);
  }
}
