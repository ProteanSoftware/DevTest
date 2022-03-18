import { Injectable } from '@angular/core';
import { environment } from "../../environments/environment";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {CreateCustomerDto, CustomerDto, CustomerTypes} from "../models/customer.dto";

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  public readonly CUSTOMERS: string = '/customers';
  public apiUrl: string = environment.urlAddress;

  constructor(
    private httpClient: HttpClient) { }

  public GetCustomers(): Observable<CustomerDto[]> {
    return this.httpClient.get<CustomerDto[]>(this.apiUrl + this.CUSTOMERS);
  }

  public GetCustomer(customerId: number): Observable<CustomerDto> {
    return this.httpClient.get<CustomerDto>(this.apiUrl + this.CUSTOMERS + '/' + customerId);
  }

  public GetCustomerTypes(): Observable<CustomerTypes[]> {
    return this.httpClient.get<CustomerTypes[]>(this.apiUrl + this.CUSTOMERS + '/types');
  }

  public CreateCustomer(customer: CreateCustomerDto): Observable<CustomerDto> {
    return this.httpClient.post<CustomerDto>(this.apiUrl + this.CUSTOMERS, customer);
  }
}
