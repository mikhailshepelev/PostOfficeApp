import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { keys } from 'src/app/app.constants';
import { Shipment } from 'src/app/model/shipment';
import { ShipmentService } from 'src/app/services/shipment.service';

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
    private router: Router
  ) { }

  ngOnInit(): void {
    this.shipment = new Shipment();
  }

  createShipment(){
    this.submitted = true;
    console.log(this.shipment)
    this.shipmentService.createShipment(this.shipment)
        .subscribe (
          data => {
            console.log(data)
            this.router.navigate([''])
          }
        )
  }
}


