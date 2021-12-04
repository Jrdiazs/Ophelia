import { Component, OnInit } from '@angular/core';
import { DxFormComponent } from 'devextreme-angular';
import { Customers, InvoiceFilter, TypeDocument } from '../models';
import { CustomersServices, TypeDocumentServices } from '../services';

@Component({
  selector: 'app-invoice-list',
  templateUrl: './invoice-list.component.html'
})
export class InvoiceListComponent implements OnInit {

  customers: Customers[] = [];

  buttonOptions: any = {
    text: 'Buscar',
    type: 'success',
    useSubmitBehavior: true,
  };

  invoiceFilter: InvoiceFilter = new InvoiceFilter();


  constructor(private customerServices: CustomersServices) {
    
  }

  ngOnInit() {
    this.customerServices.GetCustomersList().subscribe(result =>
    {
      if (result.success)
          this.customers = result.data;
    },
      error => console.error(error));

    
  }
  onFormSubmit(e) { }
}
