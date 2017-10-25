import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from "@angular/router";
import { ProductService } from "app/services/product.service";
import { Product } from "app/models/product";

@Component({
  selector: 'app-product-details-route',
  templateUrl: './product-details-route.component.html',
  styleUrls: ['./product-details-route.component.css']
})
export class ProductDetailsRouteComponent implements OnInit {
  private id: number;
  product: Product;
  title:string;

  constructor(private route: ActivatedRoute, private productSvc: ProductService) {


  }

  ngOnInit() {

    this.route.queryParams.subscribe(params => {
      this.title = params["additionnalItem"];
    });

    this.route.params.subscribe(params => this.id = parseInt(params['id'], 10));

    this.route.params
      .switchMap((params: Params) => this.productSvc.getProductById(+params['id']))
      .subscribe(product => this.product = product);

    let id = +this.route.snapshot.params['id'];

    console.log(this.id);

  }

}
