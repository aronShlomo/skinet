import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Product } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  constructor(private http: HttpClient) { }


  baseUrl = "https://localhost:5269/api/";

  getProduct()
  {
    return this.http.get<Pagination<Product[]>>(this.baseUrl + 'product');
  }


}
