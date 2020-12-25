import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Bag } from 'src/app/model/bag';
import { Shipment } from 'src/app/model/shipment';
import { ShipmentService } from 'src/app/services/shipment.service';

@Component({
  selector: 'app-bags-list',
  templateUrl: './bags-list.component.html',
  styleUrls: ['./bags-list.component.css']
})
export class BagsListComponent implements OnInit {

  id: number;
  shipment: Shipment;
  bags: Bag[];
  parcelsCount: number = 0;

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
            this.countParcels();
          }
        )
  }

  viewParcels(id: number) {

  }

  createParcelsBag(id: number) {
    this.router.navigate([`shipment/${id}/parcelsbag`])
  }

  createLettersBag() {
  }

  private countParcels() {
    for (var i = 0; i < this.shipment.bags.length; i++) {
      if (this.shipment.bags[i].discriminator === 'ParcelsBag') {
        this.parcelsCount++;
      }
    }
  }
}
