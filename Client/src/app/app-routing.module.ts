import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BagsListComponent } from './components/bags-list/bags-list.component';
import { ParcelsbagComponent } from './components/parcelsbag/parcelsbag.component';
import { ShipmentComponent } from './components/shipment/shipment.component';
import { ShipmentsListComponent } from './components/shipments-list/shipments-list.component';


const routes: Routes = [
  {path: '', component: ShipmentsListComponent},
  {path: 'shipment', component: ShipmentComponent},
  {path: 'shipment/:id', component: BagsListComponent } ,
  {path: 'shipment/:id/parcelsbag', component: ParcelsbagComponent},
  {path: 'bags', component: BagsListComponent}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
