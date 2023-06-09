import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OfferCardComponent } from './components/offer-card/offer-card.component';
import { BookingCardComponent } from './components/booking-card/booking-card.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SharedRoutingModule } from './shared-routing.module';

@NgModule({
  declarations: [
    OfferCardComponent,
    BookingCardComponent,
    NavbarComponent
  ],
  imports: [
    CommonModule,
    SharedRoutingModule
  ],
  exports:[
    BookingCardComponent, OfferCardComponent, NavbarComponent
  ]
})
export class SharedModule { }
