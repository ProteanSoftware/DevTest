export interface JobModel {
  jobId: number;
  engineer: string;
  when: Date;
  customerName: string;
  customerType: string;
}

export interface BaseJobModel {
  engineer: string;
  when: Date;
  customerId: number;
}
