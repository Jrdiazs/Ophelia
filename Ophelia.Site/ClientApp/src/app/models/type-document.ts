import { BaseResponse } from "./base-response";

export class TypeDocument {
  id: number;
  typeDocumentName: string;
  typeDocumentNameShort: string;
}
export class TypeDocumentResponseList extends BaseResponse {
  data: TypeDocument[];
}

export class TypeDocumentResponse extends BaseResponse {
  data: TypeDocument;
}
