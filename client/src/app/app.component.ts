import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IProduct } from './models/product';
import { IPagination } from './models/pagination';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
   title = 'My View - Store';
   products: IProduct[];
   constructor(private http: HttpClient) {}

   ngOnInit(): void {
    this.http.get('https://localhost:5001/api/products?pageSize=70').subscribe((res: IPagination) => {
      this.products = res.data;
      console.log(res);
    }, error => {
      console.log(error)
    });
  }
}
