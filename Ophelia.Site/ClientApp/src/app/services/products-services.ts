import { Component, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment'
import { ProductsResponseList } from '../models'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class ProductsServices {
  constructor(private http: HttpClient) {
  }

  GetProducts(): Observable<ProductsResponseList> {
    return this.http.get<ProductsResponseList>(environment.ApiOphelia + 'Products/GetProducts');
  }
}
