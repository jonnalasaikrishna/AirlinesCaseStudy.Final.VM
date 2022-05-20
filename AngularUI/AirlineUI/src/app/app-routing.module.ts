import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGaurd } from './services/auth.gaurd';
import { BookingComponent} from './bookings/booking.component';
import { InventorysComponent} from './inventorys/inventorys.component';
import {SearchflightComponent} from './searchflight/searchflight.component'
const routes: Routes = [

  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full'
  },
  
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  },
  {
    path: 'inventorys',
    component: InventorysComponent
  },
  {
    path: 'bookings',
    component: BookingComponent
  },
  {
    path: 'searchflight',
    component: SearchflightComponent
  }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }