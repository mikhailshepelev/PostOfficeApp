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
    this.router.navigate([`shipment/${id}/bags`])
  }

  createShipment() {
    this.router.navigate(['shipment'])
  }

  finalize(id: number, flightDate: Date) {
    if (this.compareDate(new Date(), flightDate) > 0) {
      console.log(new Date())
      alert("Flight date of shipment cannot be in the past at the moment of finalizing")
    } else {
      this.shipmentService.finalizeShipment(id).subscribe(
        data => {console.log(data),
        this.listShipments()
        }
      );
    }
  }

  compareDate(date1: Date, date2: Date): number
{
  let d1 = new Date(date1); let d2 = new Date(date2);

  let same = d1.getTime() === d2.getTime();
  if (same) return 0;

  if (d1 > d2) return 1;
  if (d1 < d2) return -1;
}
}
