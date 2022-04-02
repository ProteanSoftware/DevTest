import { CustomerTypeModel } from './../models/customer-type.Model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CustomerTypeService {

  private customerRoute = `http://localhost:63235/customerType`

  constructor(private httpClient: HttpClient) { }

  public GetCustomerTypes(): Observable<CustomerTypeModel[]> {
    return this.httpClient.get<CustomerTypeModel[]>(`${this.customerRoute}`);
  }
}
