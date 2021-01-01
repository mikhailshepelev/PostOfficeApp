import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Bag } from 'src/app/model/bag';
import { BagService } from 'src/app/services/bag.service';
import { Location } from '@angular/common';
import { parcelsBagDiscriminator } from 'src/app/app.constants';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-parcelsbag',
  templateUrl: './parcelsbag.component.html',
  styleUrls: ['./parcelsbag.component.css']
})
export class ParcelsbagComponent implements OnInit {

  id: number
  bag: Bag
  submitted = false;

  constructor(
    private bagService: BagService,
    private route: ActivatedRoute,
    private location: Location,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.bag = new Bag();
    this.bag.discriminator = parcelsBagDiscriminator;
    this.bag.shipmentId = this.id;
  }

  createBag() {
    this.bagService.createParcelsBag(this.bag)
        .subscribe (
          data => {
            this.submitted = true;
            this.toastr.success("Bag has been succesfully created!")
            this.location.back();
          }
        )
  }

  backClicked() {
    this.location.back();
  }
}
