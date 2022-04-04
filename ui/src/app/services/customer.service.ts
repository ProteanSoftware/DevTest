import { CustomerModel, BaseCustomerModel } from './../models/customer.Model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  private customerRoute = `http://localhost:63235/customer`

  constructor(private httpClient: HttpClient) { }

  public GetCustomers(): Observable<CustomerModel[]> {
    return this.httpClient.get<CustomerModel[]>(`${this.customerRoute}`);
  }

  public GetCustomer(id: number): Observable<CustomerModel> {
    return this.httpClient.get<CustomerModel>(`${this.customerRoute}/${id}`);
  }  

  public CreateCustomer(customer: BaseCustomerModel): Promise<object> {
    return this.httpClient.post(`${this.customerRoute}`, customer).toPromise();
  }
}
