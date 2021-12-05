import { Component, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TypeDocumentResponseList } from '../models'
import { Observable } from 'rxjs';
import { BaseServices } from './base-services';

@Injectable({
  providedIn: 'root',
})

export class TypeDocumentServices extends BaseServices {
  constructor(http: HttpClient) {
    super(http);
  }

  getTypeDocuments(): Observable<TypeDocumentResponseList> {
    return this.http.get<TypeDocumentResponseList>(`${this.apiOphelia}/TypeDocument/GetTypeDocuments`);
  }
}
