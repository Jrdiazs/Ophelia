import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";

export class BaseServices
{
  apiOphelia: string;
  constructor(public http: HttpClient) {
    this.apiOphelia = environment.ApiOphelia;
  }
}
