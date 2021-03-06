import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { InvoiceListComponent } from './invoice/invoice-list.component';
import { InvoiceCreateComponent } from './invoice/invoice-create.component';
import { InvoiceDetailComponent } from './invoice/invoice-detail.component';

//dev express
import {
  DxButtonModule, DxDataGridModule, DxToastModule, DxSelectBoxModule, DxDateBoxModule, DxTemplateModule, DxNumberBoxModule, DxTextBoxModule, DxFormModule, DxFormComponent
} from 'devextreme-angular';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    InvoiceListComponent,
    InvoiceCreateComponent,
    InvoiceDetailComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    DxButtonModule,
    DxTextBoxModule,
    DxNumberBoxModule,
    DxSelectBoxModule,
    DxDataGridModule,
    DxTemplateModule,
    DxFormModule,
    DxToastModule,
    DxDateBoxModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'invoice-list', component: InvoiceListComponent },
      { path: 'invoice-create', component: InvoiceCreateComponent },
      { path: 'invoice-detail', component: InvoiceDetailComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
