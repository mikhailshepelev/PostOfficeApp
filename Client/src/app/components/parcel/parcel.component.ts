import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Parcel } from 'src/app/model/parcel';
import { ParcelService } from 'src/app/services/parcel.service';
import { Location } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-parcel',
  templateUrl: './parcel.component.html',
  styleUrls: ['./parcel.component.css']
})
export class ParcelComponent implements OnInit {

  id: number
  parcel: Parcel
  submitted = false;

  constructor(
    private parcelService: ParcelService,
    private route: ActivatedRoute,
    private location: Location,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['bagid'];
    this.parcel = new Parcel();
    this.parcel.parcelsBagId = this.id;
  }

  createParcel() {
    this.parcelService.createParcel(this.parcel)
        .subscribe (
          data => {
            this.submitted = true
            this.toastr.success("Parcel has been succesfully created!")
            this.location.back()
          }
        )
  }

  backClicked() {
    this.location.back();
  }
}
