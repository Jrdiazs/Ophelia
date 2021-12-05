import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Customers, Invoice, InvoiceFilter } from '../models';
import { CustomersServices, InvoicesServices } from '../services';

@Component({
  selector: 'app-invoice-list',
  templateUrl: './invoice-list.component.html'
})
export class InvoiceListComponent implements OnInit {
  customers: Customers[] = [];

  buttonOptions: any = {
    text: 'Search',
    type: 'success',
    useSubmitBehavior: true,
  };

  invoiceFilter: InvoiceFilter = new InvoiceFilter();

  invoices: Invoice[];

  constructor(private customerServices: CustomersServices, private invoiceServices: InvoicesServices, private route: Router) {
  }

  ngOnInit() {
    this.customerServices.GetCustomersList().subscribe(result => {
      if (result.success)
        this.customers = result.data;
    },
      error => console.error(error));
  }
  onFormSubmit(e) {
    this.invoiceServices.GetInvoicesSearch(this.invoiceFilter).subscribe(result => {
      if (result.success)
        this.invoices = result.data;
    },
      error => console.error(error));
  }
  addInvoice(e) {
    this.route.navigate(['/invoice-create'], { queryParams: { id: 0 } });
  }
}
