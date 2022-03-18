import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, NgForm, Validators} from '@angular/forms';
import {EngineerService} from '../services/engineer.service';
import {JobService} from '../services/job.service';
import {CreateJobDto, JobDto} from '../models/job.dto';
import {CustomerService} from "../services/customer.service";
import {CustomerDto} from "../models/customer.dto";
import {DatePipe} from "@angular/common";

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.scss']
})
export class JobComponent implements OnInit {

  todayDate: string;

  public jobFormGroup: FormGroup;

  public engineers: string[] = [];
  public customers: CustomerDto[] = [];
  public jobs: JobDto[] = [];

  constructor(
    private engineerService: EngineerService,
    private jobService: JobService,
    private customerService: CustomerService,
    private datePipe: DatePipe) {

  }

  ngOnInit() {
    this.getEngineers();
    this.getJobs();
    this.getCustomers();
    this.createJobForm();
    this.todayDate = this.datePipe.transform(new Date(), 'yyyy-MM-dd')
  }

  getEngineers() {
    this.engineerService.GetEngineers().subscribe(
      engineers => this.engineers = engineers);
  }

  getJobs() {
    this.jobService.GetJobs().subscribe(
      jobs => this.jobs = jobs);
  }

  getCustomers() {
    this.customerService.GetCustomers().subscribe(
      customers => this.customers = customers)
  }

  createJobForm() {
    this.jobFormGroup = new FormGroup({
      dateWhen: new FormControl('', [Validators.required]),
      engineer: new FormControl('', [Validators.required]),
      customer: new FormControl('', [Validators.required])
    });
  }

  changeEngineer(event) {
    this.jobFormGroup.get('engineer').setValue(event.target.value);
  }

  changeCustomer(event) {
    this.jobFormGroup.get('customer').setValue(event.target.value);
  }

  public validateControl = (controlName: string) => {
    return this.jobFormGroup.controls[controlName].invalid
      && this.jobFormGroup.controls[controlName].touched;
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.jobFormGroup.controls[controlName].hasError(errorName);
  }

  onSubmit(jobFormValue): void {
    const jobDto: CreateJobDto = {
      engineer: jobFormValue.engineer,
      customerId: jobFormValue.customer,
      when: jobFormValue.dateWhen
    }
    if (this.jobFormGroup.valid) {
      this.jobService.CreateJob(jobDto).subscribe();
    }
  }
}
