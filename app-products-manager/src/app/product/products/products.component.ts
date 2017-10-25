import { Component, OnInit, ViewEncapsulation, ViewChild, AfterViewInit } from '@angular/core';
import { ProductService } from "app/services/product.service";
import { FormControl } from "@angular/forms";
import "rxjs";
import { Product } from "app/models/product";
import { Router, NavigationExtras } from "@angular/router";

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css'],
  styles: [
    `h2{
      color:yellowgreen;
    }`
  ],
  encapsulation: ViewEncapsulation.Emulated,
  providers: [ProductService]
})
export class ProductsComponent implements OnInit, AfterViewInit {
  @ViewChild("details") details;
  title: string = "List of products";
  myColor: string = "#2e7d32";
  activeProduct: Product = null;
  errorMessage:string;
  pages:Array<number> = [];
  products: Array<Product> = [
    new Product(1, "AA130", "Clavier", "Clavier 102 touches", 123.89),
    new Product(2, "AA3400", "Ecran", "Ecran Full HD", 299.99),
    new Product(2, "AA3400", "Ecran", "Ecran Full HD", 299.99),
    new Product(2, "AA3400", "Ecran", "Ecran Full HD", 299.99),
    new Product(2, "AA3400", "Ecran", "Ecran Full HD", 299.99),
    new Product(2, "AA3400", "Ecran", "Ecran Full HD", 299.99),
    new Product(2, "AA3400", "Ecran", "Ecran Full HD", 299.99),
    new Product(2, "AA3400", "Ecran", "Ecran Full HD", 299.99),
    new Product(2, "AA3400", "Ecran", "Ecran Full HD", 299.99),
    new Product(2, "AA3400", "Ecran", "Ecran Full HD", 299.99),
    new Product(2, "AA3400", "Ecran", "Ecran Full HD", 299.99),
    new Product(2, "AA3400", "Ecran", "Ecran Full HD", 299.99),
    new Product(2, "AA3400", "Ecran", "Ecran Full HD", 299.99),
    new Product(2, "AA3400", "Ecran", "Ecran Full HD", 299.99)
  ]

  constructor(private productSvc: ProductService, public router:Router) {
    productSvc.getProducts().subscribe(products => this.products = products); 
    
    // productSvc.addProduct(new Product(4, "AZER3", "Souris", "Souris de gamer", 89))
              // .subscribe(result => console.log(result)); 
  }

  setActiveProduct(event, idProduct) {
    this.productSvc.getProductById(idProduct).subscribe(
        product => this.activeProduct = product,
        error =>  this.errorMessage = <any>error);
  }

  ngOnInit() {
  }

  ngAfterViewInit() {
    console.log(this.details);
  }

  onDeleteProduct(product: Product) {
    var index = this.products.indexOf(product);
    this.products.splice(index, 1);
    this.activeProduct = null;
  }

  goToAdd(event){
    this.router.navigate(['product/add-code']);
  }

  gotoDetails(id:number){
    let navigationExtras:NavigationExtras = {
      queryParams: { 'additionnalItem': 'Specific title' }
    };

    this.router.navigate(['product/details', id ], navigationExtras)
  }

  nbPages(){
    let nb = Math.ceil(this.products.length / 5);
    return Array(nb).fill(1).map((x,i)=> i);
  }
}
