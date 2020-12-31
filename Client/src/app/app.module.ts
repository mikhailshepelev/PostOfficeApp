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
import { LettersbagComponent } from './components/lettersbag/lettersbag.component';
import { ParcelsListComponent } from './components/parcels-list/parcels-list.component';
import { ParcelComponent } from './components/parcel/parcel.component';
import { ToastrModule } from 'ngx-toastr';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    ShipmentsListComponent,
    ShipmentComponent,
    BagsListComponent,
    ParcelsbagComponent,
    LettersbagComponent,
    ParcelsListComponent,
    ParcelComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    FontAwesomeModule,
    BrowserAnimationsModule
  ],
  providers: [
    ShipmentService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
