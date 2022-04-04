import { ActivatedRoute } from "@angular/router";
import { Component, OnInit } from "@angular/core";
import { CustomerModel } from "../models/customer.Model";
import { CustomerService } from "../services/customer.service";

@Component({
  selector: "app-customer-detail",
  templateUrl: "./customer-detail.component.html",
  styleUrls: ["./customer-detail.component.scss"],
})
export class CustomerDetailComponent implements OnInit {
  private id: number;

  public customer: CustomerModel;

  constructor(
    private route: ActivatedRoute,
    private customerService: CustomerService
  ) {}

  ngOnInit() {
    this.id = this.route.snapshot.params.id;
    this.customerService.GetCustomer(this.id).subscribe(
      (customerData) => {
        this.customer = customerData;
      },
      (error) => {
        this.handleError(error);
      }
    );
  }
  
  handleError(error) {
    let errorMessage = "";

    if (error.error instanceof ErrorEvent) {
      // client-side error

      errorMessage = `${error.error.message}`;
    } else {
      // server-side error

      errorMessage = `${error.status}\nMessage: ${error.message}`;
    }

    window.alert(errorMessage);
  }
}
