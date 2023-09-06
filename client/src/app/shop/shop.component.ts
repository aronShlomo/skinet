import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ShopService } from './shop.service';
import { Product } from '../shared/models/product';
import { Brands } from '../shared/models/brands';
import { Types } from '../shared/models/types';
import { ShopParams } from '../shared/models/shopParams';
import {CarouselModule} from 'ngx-bootstrap/carousel';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit   {
  @ViewChild('search') searchTerm?: ElementRef;

 product: Product[] = []; 
 brands: Brands[] = [];
 types: Types[] = [];
 shopParams = new ShopParams();
 totalCount = 0;

constructor(private shopServise: ShopService){}


  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();    
  }


  getProducts(){
    this.shopServise.getProduct(this.shopParams).subscribe({
        next: response => 
        {this.product = response.data;
         this.shopParams.pageNumber = response.pageIndex;
         this.shopParams.pageSize = response.pageSize;
         this.totalCount = response.count;
        },
        error: error => console.log(error)
      });
  }

  getBrands(){
    this.shopServise.getBrands().subscribe({
        next: response => this.brands = response,
        error: error => console.log(error)
      });
  }

  getTypes(){
    this.shopServise.getTypes().subscribe({
        next: response => this.types = response,
        error: error => console.log(error)
      });
  }

  onBrandSelected(brandId: number){
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onTypeSelected(typeId: number){
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onPageChanged(event: any)
  {
    if(this.shopParams.pageNumber !== event){
      this.shopParams.pageNumber = event;
      this.getProducts();
    }
  }

  onSearch(){
    this.shopParams.search = this.searchTerm?.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onReset(){
    if(this.searchTerm) this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();
  }



}
