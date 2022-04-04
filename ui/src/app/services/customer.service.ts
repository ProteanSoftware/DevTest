import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { CustomerModel } from '../models/customer.model';

@Injectable({
  providedIn: 'root'
})

export class CustomerService {
  constructor(private httpClient: HttpClient) { }

  public GetCustomerTypes(): Observable<string[]> {
    return this.httpClient.get<string[]>(environment.apiUrl + '/customer/types');
  }

  public GetCustomers(): Observable<CustomerModel[]> {
    return this.httpClient.get<CustomerModel[]>(environment.apiUrl + '/customer');
  }

  public GetCustomer(customerId: number): Observable<CustomerModel> {
    return this.httpClient.get<CustomerModel>(environment.apiUrl + `/customer/${customerId}`);
  }

  public CreateCustomer(customer: CustomerModel): Promise<object> {
    return this.httpClient.post(environment.apiUrl + '/customer', customer).toPromise();
  }
}
