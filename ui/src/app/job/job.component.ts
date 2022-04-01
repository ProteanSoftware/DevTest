import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { EngineerService } from '../services/engineer.service';
import { JobService } from '../services/job.service';
import { JobModel } from '../models/job.model';
import { CustomerModel } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';
import { Subscription } from 'rxjs/internal/Subscription';

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.scss']
})
export class JobComponent implements OnInit {

  private subs: Subscription[] = [];
  public engineers: string[] = [];
  public customers: CustomerModel[] = [];
  public jobs: JobModel[] = [];
  public newJob: JobModel = {
    jobId: null,
    engineer: null,
    customerId: null,
    customerName: null,
    when: null
  };
  public selectedCustomer: CustomerModel = undefined;
  public readonly unknown = 'Unknown';

  constructor(
    private engineerService: EngineerService,
    private customerService: CustomerService,
    private jobService: JobService) { }

  ngOnInit() {
    const getEngineersSubscription = this.engineerService.GetEngineers().subscribe(engineers => this.engineers = engineers);
    this.subs.push(getEngineersSubscription);
    const getCustomersSubscription = this.customerService.GetCustomers().subscribe(customers => this.customers = customers);
    this.subs.push(getCustomersSubscription);
    const getJobsSubscription = this.jobService.GetJobs().subscribe(jobs => this.jobs = jobs);
    this.subs.push(getJobsSubscription);

  }

  public createJob(form: NgForm): void {
    if (form.invalid) {
      alert('form is not valid');
    } else {
      this.jobService.CreateJob(this.newJob).then(() => {
        this.jobService.GetJobs().subscribe(jobs => this.jobs = jobs);
      });
    }
  }

  onSelectCustomer(e: any): void {
    this.selectedCustomer = e;
    this.newJob.customerId = this.selectedCustomer.customerId;
    this.newJob.customerName = this.selectedCustomer.name;
  }

  ngOnDestroy() {
    this.subs.forEach(sub => {
      sub?.unsubscribe();
    });
  }
}
