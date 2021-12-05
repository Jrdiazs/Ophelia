import { Component, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProductsResponseList } from '../models'
import { Observable } from 'rxjs';
import { BaseServices } from './base-services';

@Injectable({
  providedIn: 'root',
})

export class ProductsServices extends BaseServices {
  constructor(http: HttpClient) {
    super(http);
  }

  getProducts(): Observable<ProductsResponseList> {
    return this.http.get<ProductsResponseList>(`${this.apiOphelia}/Products/GetProducts`);
  }
}
