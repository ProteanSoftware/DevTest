import {CustomerDto} from "./customer.dto";

export interface JobDto {
  jobId: number;
  engineer: string;
  when: Date;
  customer: CustomerDto;
}

export interface CreateJobDto {
  engineer: string;
  when: Date;
  customerId: number;
}
