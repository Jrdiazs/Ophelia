import { Component, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment'
import {  TypeDocumentResponseList } from '../models'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class TypeDocumentServices {
  constructor(private http: HttpClient) {
  }

  GetTypeDocuments(): Observable<TypeDocumentResponseList> {
    return this.http.get<TypeDocumentResponseList>(environment.ApiOphelia + 'TypeDocument/GetTypeDocuments');
  }
}
