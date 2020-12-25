import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Bag } from 'src/app/model/bag';
import { BagService } from 'src/app/services/bag.service';

@Component({
  selector: 'app-parcelsbag',
  templateUrl: './parcelsbag.component.html',
  styleUrls: ['./parcelsbag.component.css']
})
export class ParcelsbagComponent implements OnInit {

  id: number
  bag: Bag

  constructor(
    private todoService: BagService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    this.bag = new Bag();
    this.bag.shipmentId = this.id;
  }

}
