import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Bag } from 'src/app/model/bag';
import { Parcel } from 'src/app/model/parcel';
import { BagService } from 'src/app/services/bag.service';
import { Location } from '@angular/common';
import { Shipment } from 'src/app/model/shipment';
import { ShipmentService } from 'src/app/services/shipment.service';

@Component({
  selector: 'app-parcels-list',
  templateUrl: './parcels-list.component.html',
  styleUrls: ['./parcels-list.component.css']
})
export class ParcelsListComponent implements OnInit {

  id: number;
  parcels: Parcel[];
  bag: Bag;
  shipmentId: number;
  
  constructor(
    private bagService: BagService,
    private route: ActivatedRoute,
    private router: Router,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.bag = new Bag();
    this.parcels = this.bag.parcels;
    this.id = this.route.snapshot.params['bagid'];

    this.bagService.getBag(this.id)
        .subscribe (
          data => {
            this.bag = data
            this.parcels = this.bag.parcels
          }
        )
  }

  createParcel(shipmentId: number, bagId: number) {
    this.router.navigate([`shipment/${shipmentId}/bags/${bagId}/parcel`])  
  }

  backClicked(){
    this.location.back();
  }
}
