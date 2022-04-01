import { forEach } from '@angular-devkit/schematics';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs/internal/Subscription';
import { CustomerModel } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  subs: Subscription[] = [];
  public customerTypes: string[] = [];
  public customers: CustomerModel[] = [];
  public newCustomer: CustomerModel = {
    customerId: null,
    name: null,
    type: null
  };

  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    const getCustomersSub = this.customerService.GetCustomers()
      .subscribe(customers => this.customers = customers);
    this.subs.push(getCustomersSub);

    const getCustomerTypeSub = this.customerService.GetCustomerTypes()
      .subscribe(customerTypes => this.customerTypes = customerTypes);
    this.subs.push(getCustomerTypeSub);
  }

  public createCustomer(form: NgForm): void {
    if (form.invalid) {
      alert('form is not valid');
    } else {
      this.customerService.CreateCustomer(this.newCustomer).then(() => {
        this.subs.push(this.customerService.GetCustomers().subscribe(jobs => this.customers = jobs));
      });
    }
  }

  ngOnDestroy() {
    this.subs.forEach(sub => {
      sub?.unsubscribe();
    });
  }

}
