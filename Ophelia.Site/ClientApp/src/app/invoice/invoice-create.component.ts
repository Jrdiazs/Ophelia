import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DxFormComponent } from 'devextreme-angular';
import { Customers, Invoice, InvoiceFilter, TypeDocument } from '../models';
import { CustomersServices, InvoicesServices, TypeDocumentServices } from '../services';

@Component({
  selector: 'app-invoice-create',
  templateUrl: './invoice-create.component.html'
})
export class InvoiceCreateComponent implements OnInit {
  invoiceId?: number;
  invoice: Invoice = new Invoice();
  customers: Customers[] = [];
  showDetail: boolean = false;
  buttonOptions: any = {
    text: 'Save',
    type: 'success',
    useSubmitBehavior: true,
  };

  params: any;

  constructor(private customerServices: CustomersServices, private invoiceServices: InvoicesServices, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.invoice.invoiceNumber = null;
    this.route.queryParams.subscribe(params => {
      this.invoiceId = params["id"];
      this.invoice.id = this.invoiceId;
      if (this.invoiceId == 0)
        this.invoice.creationDate = new Date();
      else {
        this.getInvoicedFindById(this.invoiceId);
      }
    });

    this.customerServices.GetCustomersList().subscribe(result => {
      if (result.success)
        this.customers = result.data;
    },
      error => console.error(error));
  }
  onFormSubmit(e) {
    this.invoiceServices.SaveInvoice(this.invoice).subscribe(result => {
      if (result.success)
        this.invoice = result.data;
    },
      error => console.error(error));
  }
  getInvoicedFindById(invoiceId: number) {
    this.invoiceServices.GetInvoiceById(invoiceId).subscribe(result => {
      if (result.success)
      {
        this.invoice = result.data;
        this.showDetail = true;
        this.params = { id: this.invoice.id};
      }
        
    },
      error => console.error(error));
  }
}
