import { Component, OnInit } from '@angular/core';
import { Shipment } from 'src/app/model/shipment';
import { ShipmentService } from 'src/app/services/shipment.service';

@Component({
  selector: 'app-shipments-list',
  templateUrl: './shipments-list.component.html',
  styleUrls: ['./shipments-list.component.css']
})
export class ShipmentsListComponent implements OnInit {

  shipments: Shipment[];

  constructor(private shipmentService: ShipmentService) { }

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
}
