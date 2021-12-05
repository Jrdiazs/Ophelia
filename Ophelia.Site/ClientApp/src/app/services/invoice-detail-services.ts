import { Component, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment'
import { InvoiceDetailResponseList, InvoiceDetail, InvoiceDetailResponse } from '../models/'
import { Observable } from 'rxjs';
import { BaseResponse } from '../models/base-response';

@Injectable({
  providedIn: 'root',
})

export class InvoicesDetailServices {
  constructor(private http: HttpClient) {
  }

  SaveInvoiceDetail(request: InvoiceDetail): Observable<InvoiceDetailResponse> {
    return this.http.post<InvoiceDetailResponse>(environment.ApiOphelia + 'InvoiceDetail/SaveInvoiceDetail', request);
  }

  GetInvoiceById(invoiceId: number): Observable<InvoiceDetailResponseList> {
    return this.http.get<InvoiceDetailResponseList>(environment.ApiOphelia + 'InvoiceDetail/GetInvoiceDetailFromByInvoiceId?invoiceId=' + invoiceId);
  }

  DeleteInvoiceDetail(invoiceDetailId: number): Observable<BaseResponse> {
    return this.http.post<BaseResponse>(environment.ApiOphelia + 'InvoiceDetail/DeleteInvoiceDetail?invoiceDetailId=' + invoiceDetailId, invoiceDetailId);
  }
}
