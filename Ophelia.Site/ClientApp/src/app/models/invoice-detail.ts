import { BaseResponse } from "./base-response";

export class InvoiceDetail {
  id: number;
  invoice: number;
  product: number;
  productQuantity: number;
  productValue: number;
  totalValue: number;
  creationDate: Date;
}

export class InvoiceDetailResponseList extends BaseResponse {
  data: InvoiceDetail[];
}

export class InvoiceDetailResponse extends BaseResponse {
  data: InvoiceDetail;
}
