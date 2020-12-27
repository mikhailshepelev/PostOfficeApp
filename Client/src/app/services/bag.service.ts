import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { baseUrl } from '../app.constants';
import { Bag } from '../model/bag';

@Injectable({
  providedIn: 'root'
})
export class BagService {

  private url = `${baseUrl}/bags`

  constructor(private httpClient: HttpClient) { }

  createParcelsBag(bag: Bag) {
    return this.httpClient.post(`${this.url}/parcelsbag`, bag)
  }

  createLettersBag(bag: Bag) {
    return this.httpClient.post(`${this.url}/lettersbag`, bag)
  }

  getBag(id: number): Observable<Bag> {
    return this.httpClient.get<Bag>(`${this.url}/${id}`);
  }
}
