import { Component, OnInit } from '@angular/core';
import { ShopService } from './shop.service';
import { Product } from '../shared/models/product';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit   {

 product: Product[] = []; 

constructor(private shopServise: ShopService){}


  ngOnInit(): void {
     this.shopServise.getProduct().subscribe(
      {
        next: response => this.product = response.data,
        error: error => console.log(error)
      });
  }

}
