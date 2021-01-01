import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule} from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
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
import { ErrorInterceptor } from './error-handling/error.interceptor';
import { NotFoundComponent } from './error-handling/not-found/not-found.component';
import { ServerErrorComponent } from './error-handling/server-error/server-error.component';

@NgModule({
  declarations: [
    AppComponent,
    ShipmentsListComponent,
    ShipmentComponent,
    BagsListComponent,
    ParcelsbagComponent,
    LettersbagComponent,
    ParcelsListComponent,
    ParcelComponent,
    NotFoundComponent,
    ServerErrorComponent
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
    ShipmentService,
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true}
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
