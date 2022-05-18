export interface CustomerModel {
    customerId: number;
    name: string;
    customerType: CustomerType;
  }

  export enum CustomerType{
      Large = 0,
      Small = 1
  }