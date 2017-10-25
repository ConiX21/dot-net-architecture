import { Component, OnInit } from '@angular/core';
import { Product } from "app/models/product";
import {Form} from '@angular/forms'

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  product:Product = new Product(null, null, null, null,null);
  constructor() { }
  
  ngOnInit() {
  }

  register(){
    console.log(this.product);
   

  }
}
