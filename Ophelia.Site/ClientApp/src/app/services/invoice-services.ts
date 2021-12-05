import { Component, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Invoice, InvoiceFilter, InvoiceResponse, InvoiceResponseList } from '../models/'
import { Observable } from 'rxjs';
import { BaseServices } from './base-services';

@Injectable({
  providedIn: 'root',
})

export class InvoicesServices extends BaseServices{
  constructor(http: HttpClient) {
    super(http);
  }

  getInvoicesSearch(filter: InvoiceFilter): Observable<InvoiceResponseList> {
    return this.http.post<InvoiceResponseList>(`${this.apiOphelia}/Invoice/GetInvoicesSearch`, filter);
  }
  saveInvoice(invoice: Invoice): Observable<InvoiceResponse> {
    return this.http.post<InvoiceResponse>(`${this.apiOphelia}/Invoice/SaveInvoice`, invoice);
  }

  getInvoiceById(invoiceId: number): Observable<InvoiceResponse> {
    return this.http.get<InvoiceResponse>(`${this.apiOphelia}/Invoice/GetInvoiceById?invoiceId=${invoiceId}`);
  }
}
