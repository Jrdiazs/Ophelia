import { Component, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment'
import { Invoice, InvoiceFilter, InvoiceResponse, InvoiceResponseList } from '../models/'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class InvoicesServices {
  constructor(private http: HttpClient) {
  }

  GetInvoicesSearch(request: InvoiceFilter): Observable<InvoiceResponseList> {
    return this.http.post<InvoiceResponseList>(environment.ApiOphelia + 'Invoice/GetInvoicesSearch', request);
  }
}
