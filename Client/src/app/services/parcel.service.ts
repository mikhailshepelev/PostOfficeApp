import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { baseUrl } from '../app.constants';
import { Parcel } from '../model/parcel';

@Injectable({
  providedIn: 'root'
})
export class ParcelService {

  private url = `${baseUrl}/parcels`

  constructor(private httpClient: HttpClient) { }

  createParcel(parcel: Parcel) {
    return this.httpClient.post(`${this.url}`, parcel)
  }
}
