import { BaseResponse } from "./base-response";

export class Invoice {
  id: number;
  invoiceNumber: number;
  customer: number;
  totalBill: number;
  creationDate: Date;
}

export class InvoiceRsponseList extends BaseResponse {
  data: Invoice[];
}

export class InvoiceRsponse extends BaseResponse {
  data: Invoice;
}
