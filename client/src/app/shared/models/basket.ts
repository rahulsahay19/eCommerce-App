// import {v4 as uuidv4} from 'uuid/v4';
import { uuid } from 'uuidv4';

export interface IBasket {
    id: string;
    items: IBasketItem[];
    clientSecret?: string;
    paymentIntentId?: string;
    deliveryMethodId?: number;
  }

export interface IBasketItem {
    id: number;
    productName: string;
    price: number;
    quantity: number;
    pictureUrl: string;
    brand: string;
    type: string;
  }

export class Basket implements IBasket {
    id = uuid();
    items: IBasketItem[] = [];
   }

export interface IBasketTotals {
  shipping: number;
  subTotal: number;
  total: number;
}
