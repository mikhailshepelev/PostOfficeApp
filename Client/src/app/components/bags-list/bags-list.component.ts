import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Bag } from 'src/app/model/bag';
import { Shipment } from 'src/app/model/shipment';
import { ShipmentService } from 'src/app/services/shipment.service';
import { lettersBagDiscriminator } from 'src/app/app.constants';
import { parcelsBagDiscriminator } from 'src/app/app.constants';

@Component({
  selector: 'app-bags-list',
  templateUrl: './bags-list.component.html',
  styleUrls: ['./bags-list.component.css']
})
export class BagsListComponent implements OnInit {

  id: number;
  shipment: Shipment;
  bags: Bag[];
  parcelsBagDisc = parcelsBagDiscriminator;
  lettersBagDisc = lettersBagDiscriminator;

  constructor(private shipmentService: ShipmentService,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit(): void {
    this.shipment = new Shipment();
    this.bags = this.shipment.bags;
    this.id = this.route.snapshot.params['id'];
    this.shipmentService.getShipment(this.id)
        .subscribe (
          data => {
            this.shipment = data
            this.bags = this.shipment.bags
          }
        )
  }

  viewParcels(shipmentId: number, bagId: number) {
    this.router.navigate([`shipment/${shipmentId}/bags/${bagId}/parcels`])
  }

  createParcelsBag(id: number) {
    this.router.navigate([`shipment/${id}/bags/parcelsbag`])
  }

  createLettersBag(id: number) {
    this.router.navigate([`shipment/${id}/bags/lettersbag`])
  }
}
