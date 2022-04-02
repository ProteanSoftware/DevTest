import { NgForm } from '@angular/forms';
import { CustomerTypeModel } from './../models/customer-type.Model';
import { CustomerTypeService } from './../services/customer-type.service';
import { CustomerModel, BaseCustomerModel } from './../models/customer.Model';
import { CustomerService } from './../services/customer.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  public customers: CustomerModel[] = [];
  public customerTypes: CustomerTypeModel[] = [];

  public newCustomer: BaseCustomerModel = {
    name: null,
    type: null
  };

  constructor(private customerService: CustomerService, private customerTypeService: CustomerTypeService) { }

  ngOnInit(): void {
    this.customerService.GetCustomers().subscribe(customers => this.customers = customers, error => this.handleError(error));
    this.customerTypeService.GetCustomerTypes().subscribe(customerTypes => this.customerTypes = customerTypes, error => this.handleError(error));
  }

  public createCustomer(form: NgForm): void {
    if (form.invalid) {
      alert('form is not valid');
    } else {
      this.customerService.CreateCustomer(this.newCustomer).then(() => {
        this.customerService.GetCustomers().subscribe(customers => this.customers = customers, error => this.handleError(error));
      });
    }
  }

  handleError(error) {
    let errorMessage = "";

    if (error.error instanceof ErrorEvent) {
      errorMessage = `${error.error.message}`;
    } else {
      errorMessage = `${error.status}\nMessage: ${error.message}`;
    }

    window.alert(errorMessage);
  }

}
