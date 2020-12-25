import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule} from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ShipmentService } from './services/shipment.service';
import { ShipmentsListComponent } from './components/shipments-list/shipments-list.component';
import { ShipmentComponent } from './components/shipment/shipment.component';
import { FormsModule } from '@angular/forms';
import { BagsListComponent } from './components/bags-list/bags-list.component';
import { ParcelsbagComponent } from './components/parcelsbag/parcelsbag.component';

@NgModule({
  declarations: [
    AppComponent,
    ShipmentsListComponent,
    ShipmentComponent,
    BagsListComponent,
    ParcelsbagComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    ShipmentService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
