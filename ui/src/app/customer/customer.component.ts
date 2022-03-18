import {Component, OnInit} from '@angular/core';
import {CustomerService} from "../services/customer.service";
import {CreateCustomerDto, CustomerDto, CustomerTypes} from "../models/customer.dto";
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  public customers: CustomerDto[] = [];
  public customerTypes: CustomerTypes[] = [];

  public customerForm: FormGroup;

  constructor(private customerService: CustomerService) {
  }

  ngOnInit(): void {
    this.getCustomers();
    this.getCustomerTypes();
    this.createCustomerForm();
  }

  changeType(event) {
    this.customerForm.get('customerType').setValue(event.target.value);
  }

  onSubmit(customerFormValue): void {
    const customerDto: CreateCustomerDto = {
      name: customerFormValue.name,
      typeId: customerFormValue.customerType
    }
    if (this.customerForm.valid) {
      this.customerService.CreateCustomer(customerDto).subscribe(() => this.getCustomers());
    }
  }

  public validateControl = (controlName: string) => {
    return this.customerForm.controls[controlName].invalid
      && this.customerForm.controls[controlName].touched;
    }

  public hasError = (controlName: string, errorName: string) => {
    return this.customerForm.controls[controlName].hasError(errorName);
  }

  getCustomers() {
    this.customerService.GetCustomers().subscribe(
      customers => this.customers = customers);
  }

  getCustomerTypes() {
    this.customerService.GetCustomerTypes().subscribe(
      types => this.customerTypes = types);
  }

  createCustomerForm() {
    this.customerForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.minLength(5)]),
      customerType: new FormControl('', [Validators.required])
    });
  }
}
