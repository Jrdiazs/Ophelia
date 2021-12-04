import { BaseResponse } from "./base-response";

export class Customers {
  id: number;
  typeDocument: number;
  document: string;
  customerNames: string;
  customerLastNames: string;
  email: string;
  birthdayDate: Date;
  creationDate: Date;
  fullName: string;
}



export class CustomersResponseList extends BaseResponse {
  data: Customers[];
}

export class CustomersResponse extends BaseResponse {
  data: Customers;
}
