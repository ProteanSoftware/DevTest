import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CustomerModel, CustomerType } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  public customers: CustomerModel[] = [];
  CustomerType = CustomerType;
  customerTypes: string[] = [];

  public newCustomer: CustomerModel = {
    customerId: null,
    name: null,
    customerType: null
  };

  constructor(private customerService: CustomerService ) {    
    this.customerTypes = ["Large", "Small"]; //hackwork - should really be pulling from the enum directly for future proofing.
   }

  ngOnInit(): void {
    this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
  }

  public createCustomer(form: NgForm): void {
    if (form.invalid) {
      alert('form is not valid');
    } else {
      this.customerService.CreateCustomer(this.newCustomer).then(() => {
        this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
      });
    }
  }

}
