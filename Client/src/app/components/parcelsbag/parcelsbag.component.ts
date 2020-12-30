import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Bag } from 'src/app/model/bag';
import { BagService } from 'src/app/services/bag.service';
import { Location } from '@angular/common';
import { parcelsBagDiscriminator } from 'src/app/app.constants';

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
    private location: Location
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.bag = new Bag();
    this.bag.discriminator = parcelsBagDiscriminator;
    this.bag.shipmentId = this.id;
  }

  createBag() {
    this.submitted = true;
    this.bagService.createParcelsBag(this.bag)
        .subscribe (
          data => {
            this.location.back()
          }
        )
  }

  backClicked() {
    this.location.back();
  }
}
