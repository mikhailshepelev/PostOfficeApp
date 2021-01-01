import { Component, OnInit } from '@angular/core';
import { Shipment } from 'src/app/model/shipment';
import { ShipmentService } from 'src/app/services/shipment.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-shipments-list',
  templateUrl: './shipments-list.component.html',
  styleUrls: ['./shipments-list.component.css']
})
export class ShipmentsListComponent implements OnInit {

  shipments: Shipment[];

  constructor(private shipmentService: ShipmentService,
              private router: Router,
              private toastr: ToastrService) { }

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

  finalize(id: number) {
      this.shipmentService.finalizeShipment(id).subscribe(
        data => {
          this.toastr.success("Shipment has been succesfully finalized!")
          this.listShipments()
        }
      );
  }

  compareDate(date1: Date, date2: Date): number {
    let d1 = new Date(date1); let d2 = new Date(date2);

    let same = d1.getTime() === d2.getTime();
    if (same) return 0;

    if (d1 > d2) return 1;
    if (d1 < d2) return -1;
  }
}
