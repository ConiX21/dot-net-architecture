import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators, ValidatorFn, AbstractControl } from "@angular/forms";
import { Product } from "app/models/product";
import { ProductService } from "app/services/product.service";
import { Router } from "@angular/router";

export function priceValue(): ValidatorFn {
  return (control: AbstractControl): { [key: string]: any } => {
    const input = control.value,
      isValid = isNaN(input);
    if (isValid)
      return { 'price': { input } }
    else
      return null;
  };
}

@Component({
  selector: 'app-product-add-form-code',
  templateUrl: './product-add-form-code.component.html',
  styleUrls: ['./product-add-form-code.component.css']
})
export class ProductAddFormCodeComponent implements OnInit {
  productForm: FormGroup;
  product: Product = new Product(null, null, null, null, null);
  refCtrl: FormControl;
  nameCtrl: FormControl;
  descriptionCtrl: FormControl;
  priceCtrl: FormControl

  constructor(fb: FormBuilder, public productSvc: ProductService, private router:Router) {
    this.refCtrl = fb.control('', [Validators.required, Validators.minLength(3), Validators.maxLength(5)]);
    this.nameCtrl = fb.control('', [Validators.required, Validators.maxLength(45)]);
    this.descriptionCtrl = fb.control('', [Validators.required, Validators.maxLength(150)]);
    this.priceCtrl = fb.control('', [Validators.required, priceValue()]);

    this.productForm = fb.group({
      ref: this.refCtrl,
      name: this.nameCtrl,
      description: this.descriptionCtrl,
      price: this.priceCtrl,
    });

  }

  ngOnInit() {
  }

  reset() {
    this.refCtrl.setValue('');
    this.nameCtrl.setValue('');
    this.descriptionCtrl.setValue('');
    this.priceCtrl.setValue('');
  }

  register() {
    if (this.productForm.valid) {
      let lastId: number;

      this.productSvc.getLastId().subscribe(id => {
        lastId = parseInt(((<any>id).count));
        lastId++;
        this.product = new Product(lastId, this.refCtrl.value, this.nameCtrl.value, this.descriptionCtrl.value, this.priceCtrl.value);
        this.productSvc.addProduct(this.product).subscribe(result =>{
          console.log(result);
          this.router.navigate(["product/list"]);

        } , err => console.log(err));

      });

    }


  }


}
