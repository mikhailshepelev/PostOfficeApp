import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BagsListComponent } from './components/bags-list/bags-list.component';
import { LettersbagComponent } from './components/lettersbag/lettersbag.component';
import { ParcelComponent } from './components/parcel/parcel.component';
import { ParcelsListComponent } from './components/parcels-list/parcels-list.component';
import { ParcelsbagComponent } from './components/parcelsbag/parcelsbag.component';
import { ShipmentComponent } from './components/shipment/shipment.component';
import { ShipmentsListComponent } from './components/shipments-list/shipments-list.component';
import { NotFoundComponent } from './error-handling/not-found/not-found.component';
import { ServerErrorComponent } from './error-handling/server-error/server-error.component';


const routes: Routes = [
  {path: '', component: ShipmentsListComponent},
  {path: 'shipment', component: ShipmentComponent},
  {path: 'shipment/:id/bags', component: BagsListComponent } ,
  {path: 'shipment/:id/bags/parcelsbag', component: ParcelsbagComponent},
  {path: 'shipment/:id/bags/lettersbag', component: LettersbagComponent},
  {path: 'shipment/:shipmentid/bags/:bagid/parcels', component: ParcelsListComponent},
  {path: 'shipment/:shipmentid/bags/:bagid/parcel', component: ParcelComponent},
  {path: 'not-found', component: NotFoundComponent},
  {path: 'server-error', component: ServerErrorComponent},
  {path: '**', component: NotFoundComponent}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
