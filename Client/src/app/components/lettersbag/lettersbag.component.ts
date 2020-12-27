import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Bag } from 'src/app/model/bag';
import { BagService } from 'src/app/services/bag.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-lettersbag',
  templateUrl: './lettersbag.component.html',
  styleUrls: ['./lettersbag.component.css']
})
export class LettersbagComponent implements OnInit {

  id: number
  bag: Bag
  submitted = false;

  constructor(
    private bagService: BagService,
    private route: ActivatedRoute,
    private router: Router,
    private location: Location
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.bag = new Bag();
    this.bag.shipmentId = this.id;
  }

  createBag() {
    this.submitted = true;
    this.bagService.createLettersBag(this.bag)
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
