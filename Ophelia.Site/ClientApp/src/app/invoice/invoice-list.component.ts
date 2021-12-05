import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Customers, Invoice, InvoiceFilter } from '../models';
import { CustomersServices, InvoicesServices } from '../services';
import { BaseComponent } from '../util/base-component';

@Component({
  selector: 'app-invoice-list',
  templateUrl: './invoice-list.component.html'
})
export class InvoiceListComponent extends BaseComponent implements OnInit {
  customers: Customers[] = [];

  buttonOptions: any = {
    text: 'Search',
    type: 'success',
    useSubmitBehavior: true,
  };

  invoiceFilter: InvoiceFilter = new InvoiceFilter();

  invoices: Invoice[];

  constructor(private customerServices: CustomersServices, private invoiceServices: InvoicesServices, private route: Router) {
    super();
  }

  ngOnInit() {
    this.customerServices.getCustomersList().subscribe(result => {
      if (result.success)
        this.customers = result.data;
      else
        this.showError(result.message);
    },
      error => console.error(error));
  }
  onFormSubmit(e) {
    this.invoiceServices.getInvoicesSearch(this.invoiceFilter).subscribe(result => {
      if (result.success)
        this.invoices = result.data;
      else
        this.showError(result.message);
    },
      error => console.error(error));
  }
  addInvoice(e) {
    this.route.navigate(['/invoice-create'], { queryParams: { id: 0 } });
  }
}
