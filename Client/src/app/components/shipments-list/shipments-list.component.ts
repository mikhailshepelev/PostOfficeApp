import { Component, OnInit } from '@angular/core';
import { Shipment } from 'src/app/model/shipment';
import { ShipmentService } from 'src/app/services/shipment.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-shipments-list',
  templateUrl: './shipments-list.component.html',
  styleUrls: ['./shipments-list.component.css']
})
export class ShipmentsListComponent implements OnInit {

  shipments: Shipment[];

  constructor(private shipmentService: ShipmentService,
              private router: Router) { }

  ngOnInit(): void {
    this.listShipments();
  }

  listShipments() {
    this.shipmentService.getShipmentList().subscribe(
      data => {
        this.shipments = data;
      }
    )
  }

  viewBags(id: number) {
    this.router.navigate(['shipment', id])
  }

  createShipment() {
    this.router.navigate(['shipment'])
  }
}
