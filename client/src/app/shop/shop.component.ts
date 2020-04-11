import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { ShopService } from './shop.service';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/ShopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', {static: true}) searchTerm: ElementRef;
  products: IProduct[];
  brands: IBrand[];
  types: IType[];
  shopParams = new ShopParams();
  totalCount: number;
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
    this.shopService.getProducts(this.shopParams).subscribe(res => {
      this.products = res.data;
      this.shopParams.pageNumber = res.pageIndex;
      this.shopParams.pageSize = res.pageSize;
      this.totalCount = res.count;
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
  this.shopParams.brandId = brandId;
  this.shopParams.pageNumber = 1;
  this.getProducts();
 }

 onTypeSelected(typeId: number) {
   this.shopParams.typeId = typeId;
   this.shopParams.pageNumber = 1;
   this.getProducts();
 }

 onSortSelected(sort: string) {
   this.shopParams.sort = sort;
   this.getProducts();
 }

 onPageChanged(event: any) {
  if (this.shopParams.pageNumber != event)
  {
     this.shopParams.pageNumber = event;
     this.getProducts();
  }
 }

 onSearch() {
   this.shopParams.search = this.searchTerm.nativeElement.value;
   this.shopParams.pageNumber = 1;
   this.getProducts();
 }

 onReset() {
   this.searchTerm.nativeElement.value = '';
   this.shopParams = new ShopParams();
   this.getProducts();
 }
}
