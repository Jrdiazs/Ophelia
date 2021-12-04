import { BaseResponse } from "./base-response";

export class Invoice {
  id: number;
  invoiceNumber: number;
  customer: number;
  totalBill: number;
  creationDate: Date;
  customerName: string;
}

export class InvoiceResponseList extends BaseResponse {
  data: Invoice[];
}

export class InvoiceResponse extends BaseResponse {
  data: Invoice;
}
