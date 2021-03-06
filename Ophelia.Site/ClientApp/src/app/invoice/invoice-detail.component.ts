import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InvoiceDetail, Products } from '../models';
import { InvoicesDetailServices, ProductsServices } from '../services';
import { BaseComponent } from '../util/base-component';

@Component({
  selector: 'app-invoice-detail',
  templateUrl: './invoice-detail.component.html'
})
export class InvoiceDetailComponent extends BaseComponent implements OnInit {
  products: Products[] = [];
  invoiceDetail: InvoiceDetail[] = [];
 

  constructor(private invoiceDetailServices: InvoicesDetailServices, private productServices: ProductsServices, private route: ActivatedRoute) {
    super();
    this.setProductInvoice = this.setProductInvoice.bind(this);
    this.setTotalInvoice = this.setTotalInvoice.bind(this);
    this.onSaving = this.onSaving.bind(this);
  }

  ngOnInit() {
    this.loadProducts();
    this.route.queryParams.subscribe(params => {
      this.id = params["id"];
      this.loadGrid(this.id);
    });
  }

  loadGrid(invoiceId: number) {
    this.invoiceDetailServices.getInvoiceDetailFromById(this.id).subscribe(result => {
      if (result.success)
        this.invoiceDetail = result.data;
      else
        this.showError(result.message);
    }, error => console.error(error));
  }
  loadProducts() {
    this.productServices.getProducts().subscribe(result => {
      if (result.success)
        this.products = result.data;
      else
        this.showError(result.message);
    },
      error => console.error(error));
  }
  logEvent(e) { }
  setProductInvoice(newData, productId, currentRowData, textValue) {
    var product = this.products.filter(x => x.id == productId)[0];
    newData.productValue = product.priceByUnit;
    newData.totalValue = currentRowData.productQuantity * product.priceByUnit;
    newData.product = productId;
  }
  setTotalInvoice(newData, quantity, currentRowData, textValue) {
    newData.totalValue = quantity * currentRowData.productValue;
    newData.productQuantity = quantity;
  }

  saveInvoiceDetail(changes: any, grid: any) {
    var data = changes[0].data;
    var invoiceDetailId = changes[0].key;

    var invoice = new InvoiceDetail();
    var type = changes[0].type;

    if (type === "update") {
      invoice = this.invoiceDetail.filter(x => x.id == invoiceDetailId)[0];
    }
    else if (type === "insert") {
      invoice.id = 0;
      invoice.invoice = this.id;
      invoice.creationDate = new Date();
    }

    Object.getOwnPropertyNames(data).forEach(function (val, idx, array) {
      switch (val.toString()) {
        case "product":
          invoice.product = data[val];
          break;
        case "productQuantity":
          invoice.productQuantity = data[val];
          break;
        case "productValue":
          invoice.productValue = data[val];
          break;
        case "totalValue":
          invoice.totalValue = data[val];
          break;
      }
    });

    this.invoiceDetailServices.saveInvoiceDetail(invoice).subscribe(result => {
      if (result.success) {
        grid.cancelEditData();
        grid.refresh(true);

        this.loadGrid(result.data.invoice);
        this.showInfo(result.message);

      } else {
        this.showError(result.message);
      }
    }, error => console.error(error));
  }

  onSaving(e: any) {
    e.cancel = true;

    if (e.changes.length)
    {
      var type = e.changes[0].type;
      var invoiceDetailId = e.changes[0].key;
      if (type === "update" || type == "insert")
        this.saveInvoiceDetail(e.changes, e.component);
      else if (type === "remove") 
        this.deleteInvoiceDetail(invoiceDetailId, e.component);
      
    }
  }
  deleteInvoiceDetail(invoiceDetailId: number, grid: any)
  {
    this.invoiceDetailServices.deleteInvoiceDetail(invoiceDetailId).subscribe(result =>
    {
      if (result.success)
      {
        grid.cancelEditData();
        grid.refresh(true);
        this.showInfo(result.message);
        this.loadGrid(this.id);

      }
      else
      {
        this.showError(result.message);
      }
    }, error => console.error(error));
  }
  addRow(e: any) {
    e.data.productQuantity = 1;
  }
}
