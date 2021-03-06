import { BaseResponse } from "./base-response";

export class Products {
  id: number;
  productName: string;
  inventoryQuantity: number;
  priceByUnit: number;
  productDescription: string;
}

export class ProductsResponseList extends BaseResponse {
  data: Products[];
}

export class ProductsResponse extends BaseResponse {
  data: Products;
}
