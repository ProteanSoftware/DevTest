import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TypeService {

  constructor(private httpClient: HttpClient) { }

  public GetTypes(): Observable<string[]> {
    return this.httpClient.get<string[]>('http://localhost:63235/type');
  }
}
