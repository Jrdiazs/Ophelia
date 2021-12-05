import { Component, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { InvoiceDetailResponseList, InvoiceDetail, InvoiceDetailResponse } from '../models/'
import { Observable } from 'rxjs';
import { BaseResponse } from '../models/base-response';
import { BaseServices } from './base-services';

@Injectable({
  providedIn: 'root',
})

export class InvoicesDetailServices extends BaseServices {
  constructor(http: HttpClient) {
    super(http);
  }

  saveInvoiceDetail(invoice: InvoiceDetail): Observable<InvoiceDetailResponse> {
    return this.http.post<InvoiceDetailResponse>(`${this.apiOphelia}/InvoiceDetail/SaveInvoiceDetail`, invoice);
  }

  getInvoiceDetailFromById(invoiceId: number): Observable<InvoiceDetailResponseList> {
    return this.http.get<InvoiceDetailResponseList>(`${this.apiOphelia}/InvoiceDetail/GetInvoiceDetailFromByInvoiceId?invoiceId=${invoiceId}`);
  }

  deleteInvoiceDetail(invoiceDetailId: number): Observable<BaseResponse> {
    return this.http.post<BaseResponse>(`${this.apiOphelia}/InvoiceDetail/DeleteInvoiceDetail?invoiceDetailId=${invoiceDetailId}`, invoiceDetailId);
  }
}
