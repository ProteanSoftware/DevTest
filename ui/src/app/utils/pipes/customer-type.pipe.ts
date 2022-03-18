import {Pipe, PipeTransform} from "@angular/core";
import {CustomerType} from "../../enums/customer-type.";

@Pipe({ name: 'customertype'})
export class CustomerTypePipe implements PipeTransform {
  transform(typeId): string {
    return CustomerType[typeId];
  }
}
