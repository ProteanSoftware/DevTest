import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { TypeService } from '../services/type.service';
import { CustomerService } from '../services/customer.service';
import { CustomerModel } from '../models/customer.model';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  public types: string[] = [];

  public customers: CustomerModel[] = [];

  public newCustomer: CustomerModel = {
    customerId: null,
    type: null,
    name: null
  };

  constructor(
    private typeService: TypeService,
    private customerService: CustomerService) { }

  ngOnInit() {
    this.typeService.GetTypes().subscribe(types => this.types = types);
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
