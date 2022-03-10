import { CustomerModel } from "./customer.model";

export interface JobModel {
  jobId?: number;
  engineer: string;
  customerId?: number;
  when: Date;
  customer?: CustomerModel;
}
