import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BagsListComponent } from './components/bags-list/bags-list.component';
import { LettersbagComponent } from './components/lettersbag/lettersbag.component';
import { ParcelComponent } from './components/parcel/parcel.component';
import { ParcelsListComponent } from './components/parcels-list/parcels-list.component';
import { ParcelsbagComponent } from './components/parcelsbag/parcelsbag.component';
import { ShipmentComponent } from './components/shipment/shipment.component';
import { ShipmentsListComponent } from './components/shipments-list/shipments-list.component';


const routes: Routes = [
  {path: '', component: ShipmentsListComponent},
  {path: 'shipment', component: ShipmentComponent},
  {path: 'shipment/:id/bags', component: BagsListComponent } ,
  {path: 'shipment/:id/bags/parcelsbag', component: ParcelsbagComponent},
  {path: 'shipment/:id/bags/lettersbag', component: LettersbagComponent},
  {path: 'shipment/:shipmentid/bags/:bagid/parcels', component: ParcelsListComponent},
  {path: 'shipment/:shipmentid/bags/:bagid/parcel', component: ParcelComponent}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
