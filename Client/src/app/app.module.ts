import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShipmentsListComponent } from './components/shipments-list/shipments-list.component';
import { HttpClientModule } from '@angular/common/http';
import { ShipmentService } from './services/shipment.service';

@NgModule({
  declarations: [
    AppComponent,
    ShipmentsListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [ShipmentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
