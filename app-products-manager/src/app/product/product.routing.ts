import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProductsComponent } from './products/products.component';
import { ProductAddComponent } from "app/product/product-add/product-add.component";
import { ProductAddFormCodeComponent } from "app/product/product-add-form-code/product-add-form-code.component";
import { ProductDetailsRouteComponent } from "app/product/product-details-route/product-details-route.component";

const routes: Routes = [
  { path: 'list', component: ProductsComponent },
  { path: 'add', component: ProductAddComponent },
  { path: 'add-code', component: ProductAddFormCodeComponent },
  { path: 'details/:id', component: ProductDetailsRouteComponent }
];

export const routing: ModuleWithProviders = RouterModule.forChild(routes);


