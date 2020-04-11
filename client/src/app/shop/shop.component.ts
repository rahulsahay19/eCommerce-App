import { Component, OnInit } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { ShopService } from './shop.service';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: IProduct[];
  brands: IBrand[];
  types: IType[];
  brandIdSelected = 0;
  typeIdSelected = 0;
  sortSelected = 'name';
  sortOptions = [
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc'},
    { name: 'Alphabetical', value: 'name' }
  ];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.brandIdSelected, this.typeIdSelected, this.sortSelected).subscribe(res => {
      this.products = res.data;
    }, error => {
      console.log(error);
  });
}

  getBrands() {
    this.shopService.getBrands().subscribe(res => {
      // Spread operators help to spread all objects. Plus one can add additional one on top of existing ones
      this.brands = [{id: 0, name: 'All'}, ...res];
    }, error => {
      console.log(error);
    });
  }

  getTypes() {
    this.shopService.getTypes().subscribe(res => {
      this.types = [{id: 0, name: 'All'}, ...res];
    }, error => {
      console.log(error);
    });
 }

 onBrandSelected(brandId: number) {
  this.brandIdSelected = brandId;
  this.getProducts();
 }

 onTypeSelected(typeId: number) {
   this.typeIdSelected = typeId;
   this.getProducts();
 }

 onSortSelected(sort: string) {
   this.sortSelected = sort;
   this.getProducts();
 }
}
