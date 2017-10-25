import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from "@angular/http";
import 'rxjs/add/operator/map';
import { Observable } from "rxjs/Observable";
import { Product } from "app/models/product";

@Injectable()
export class ProductService {

  constructor(private http: Http) { }

  getProducts(): Observable<Array<Product>> {
    return this.http.get("http://localhost:3000/api/products")
      .map(res => res.json())
  }

  getProductById(id: number): Observable<Product> {
    
    return this.http.get(`http://localhost:3000/api/product/${id}`)
      .map(res => res.json())
      .catch(this.handleError);
  }


  addProduct(product: Product):Observable<Product>{
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    
    return this.http.post("http://localhost:3000/api/add-product", { product }, options)
      .map(res => res.json())
      .catch(this.handleError);
  }

  getLastId():Observable<number>{
    return this.http.get("http://localhost:3000/api/products-count")
      .map(res => res.json())
      .catch(this.handleError); 
  }

  private handleError(error: Response | any) {
    let errMsg: string;

    if (error instanceof Response) {
      const body = (<Response>error).text() || '';
      errMsg = `${error.status} - ${error.statusText || ''} ${body}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }

    return Observable.throw(errMsg);
  }
}
