import { Component, OnInit } from '@angular/core';
import { keys } from 'src/app/app.constants';
import { Shipment } from 'src/app/model/shipment';
import { ShipmentService } from 'src/app/services/shipment.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-shipment',
  templateUrl: './shipment.component.html',
  styleUrls: ['./shipment.component.css']
})
export class ShipmentComponent implements OnInit {

  shipment: Shipment
  submitted = false;
  airports : string[] = keys;

  constructor(
    private shipmentService: ShipmentService,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.shipment = new Shipment();
  }

  createShipment(){
    this.shipmentService.createShipment(this.shipment)
        .subscribe (
          data => {
            this.submitted = true;
            this.location.back();
          }
        )
  }

  backClicked() {
    this.location.back();
  }
}


