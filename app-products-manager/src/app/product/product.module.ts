import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductsComponent } from './products/products.component';
import { routing  } from './product.routing';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductAddComponent } from './product-add/product-add.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductAddFormCodeComponent } from './product-add-form-code/product-add-form-code.component';
import { ProductDetailsRouteComponent } from './product-details-route/product-details-route.component';
import { ProductService } from "app/services/product.service";

@NgModule({
  imports: [
    CommonModule,
    routing,
    FormsModule,
    ReactiveFormsModule
  ],
  providers :[ProductService],
  exports : [ProductsComponent],
  declarations: [
      ProductsComponent,
      ProductDetailsComponent,
      ProductAddComponent,
      ProductAddFormCodeComponent,
      ProductDetailsRouteComponent
    ]
})
export class ProductModule { }
