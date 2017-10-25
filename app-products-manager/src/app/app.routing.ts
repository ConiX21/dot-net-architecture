import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HistoryComponent } from './history/history.component';
import { ContactComponent } from './contact/contact.component';
import { HomeComponent } from './home/home.component';
import { PageNotFoundComponent } from "app/page-not-found/page-not-found.component";

const routes: Routes = [
  { path: '', component:  HomeComponent},
  { path: 'history', component:  HistoryComponent},
  { path: 'contact', component: ContactComponent},
  { path: 'product', loadChildren: 'app/product/product.module#ProductModule' },
  { path : '**' , component : PageNotFoundComponent}
];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
  