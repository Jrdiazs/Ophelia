import { Component, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CustomersResponseList } from '../models/'
import { Observable } from 'rxjs';
import { BaseServices } from './base-services';

@Injectable({
  providedIn: 'root',
})

export class CustomersServices extends BaseServices {
  constructor(http: HttpClient) {
    super(http);
  }

  getCustomersList(): Observable<CustomersResponseList> {
    return this.http.get<CustomersResponseList>(`${this.apiOphelia}/Customers/GetCustomers`);
  }
}
