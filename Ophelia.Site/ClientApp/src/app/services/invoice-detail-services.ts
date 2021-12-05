import { Component, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment'
import { InvoiceDetailResponseList, InvoiceDetail, InvoiceDetailResponse } from '../models/'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class InvoicesDetailServices {
  constructor(private http: HttpClient) {
  }

  
  SaveInvoiceDetail(request: InvoiceDetail): Observable<InvoiceDetailResponse> {
    return this.http.post<InvoiceDetailResponse>(environment.ApiOphelia + 'InvoiceDetail/SaveInvoice', request);
  }

  GetInvoiceById(invoiceId: number): Observable<InvoiceDetailResponseList> {
    return this.http.get<InvoiceDetailResponseList>(environment.ApiOphelia + 'InvoiceDetail/GetInvoiceDetailFromByInvoiceId?invoiceId=' + invoiceId);
  }
}
