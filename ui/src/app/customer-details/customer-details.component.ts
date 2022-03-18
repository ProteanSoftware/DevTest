import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {CustomerService} from "../services/customer.service";
import {CustomerDto} from "../models/customer.dto";

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.scss']
})
export class CustomerDetailsComponent implements OnInit {

  private customerId: number;

  public customer: CustomerDto;

  constructor(
    private route: ActivatedRoute,
    private customerService: CustomerService) {
      this.customerId = route.snapshot.params.id;
  }

  ngOnInit(): void {
    this.customerService.GetCustomer(this.customerId).subscribe(
      customer => this.customer = customer);
  }
}
