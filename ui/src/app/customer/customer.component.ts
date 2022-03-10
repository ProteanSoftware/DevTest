import { Component, OnInit } from '@angular/core';
import { CustomerModel } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {
  public types: string[] = ['Large', 'Small'];
  public customers: CustomerModel[] = [];
  public newCustomer: CustomerModel = {
    customerId: null,
    name: null,
    type: null
  };
  
  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
  }

  public createCustomer(): void {
    this.customerService.CreateCustomer(this.newCustomer).then(() => {
      this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
    });
  }

}
