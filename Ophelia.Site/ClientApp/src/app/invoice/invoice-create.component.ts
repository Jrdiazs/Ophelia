import { Component, OnInit } from '@angular/core';
import { DxFormComponent } from 'devextreme-angular';
import { Customers, Invoice, InvoiceFilter, TypeDocument } from '../models';
import { CustomersServices, InvoicesServices, TypeDocumentServices } from '../services';

@Component({
  selector: 'app-invoice-create',
  templateUrl: './invoice-create.component.html'
})
export class InvoiceCreateComponent implements OnInit {



  constructor(private customerServices: CustomersServices, private invoiceServices: InvoicesServices) {
    
  }

  ngOnInit() {
   
  }
  onFormSubmit(e)
  {
    
  }
}
