import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Product } from './models/product';
import { Pagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'Skinet';

  product: Product[] = [];

  constructor(private http: HttpClient){}

  ngOnInit(): void {
    this.http.get<Pagination<Product[]>>('https://localhost:5269/api/product?pageSize=50').subscribe({
    next: response => this.product = response.data, //what to do next
    error: error => console.log(error),  //handle the error
    complete: () => {  //completing the request form the api
      console.log('request comlete');
      console.log('extra statment');
    }


    })

  }


}
