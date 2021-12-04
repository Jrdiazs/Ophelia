import { Component, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment'
import { Customers, CustomersResponseList } from '../models/'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class CustomersServices {
  constructor(private http: HttpClient) {
  }

  GetCustomersList(): Observable<CustomersResponseList> {
    return this.http.get<CustomersResponseList>(environment.ApiOphelia + 'Customers/GetCustomers');
  }
}
