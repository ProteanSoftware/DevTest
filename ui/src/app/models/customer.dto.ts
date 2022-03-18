import {CustomerType} from "../enums/customer-type.";

export interface CustomerDto
{
  id: number;
  name: string;
  customerTypeId: CustomerType;
}

export interface CreateCustomerDto {
  name: string;
  typeId: number;
}

export interface CustomerTypes {
  id: number;
  name: string;
}
