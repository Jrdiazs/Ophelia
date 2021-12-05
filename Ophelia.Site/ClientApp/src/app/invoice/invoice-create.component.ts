import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Customers, Invoice } from '../models';
import { CustomersServices, InvoicesServices } from '../services';
import { BaseComponent } from '../util/base-component';

@Component({
  selector: 'app-invoice-create',
  templateUrl: './invoice-create.component.html'
})
export class InvoiceCreateComponent extends BaseComponent implements OnInit {
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
      super();
  }

  ngOnInit() {
    this.loadDropCustomers();

    this.route.queryParams.subscribe(params => {
      this.id = params["id"];
      this.invoice.id = this.id;
      if (this.id == 0)
      {
        this.invoice.invoiceNumber = null;
        this.invoice.creationDate = new Date();
      }

      else {
        this.getInvoicedFindById(this.id);
      }
    });

    
  }
  loadDropCustomers()
  {
    this.customerServices.getCustomersList().subscribe(result => {
      if (result.success)
        this.customers = result.data;
    },
      error => console.error(error));
  }
  onFormSubmit(e) {
    this.invoiceServices.saveInvoice(this.invoice).subscribe(result => {
      if (result.success) {
        this.invoice = result.data;
        this.showDetail = true;
        this.params = { id: this.invoice.id };
      } else this.showError(result.message);
    },
      error => console.error(error));
  }
  getInvoicedFindById(invoiceId: number) {
    this.invoiceServices.getInvoiceById(invoiceId).subscribe(result => {

      if (result.success)
      {
        this.invoice = result.data;
        this.showDetail = true;
        this.params = { id: this.invoice.id };
      }
      else
      {
        this.showError(result.message);
      }

    },
      error => console.error(error));
  }

}
