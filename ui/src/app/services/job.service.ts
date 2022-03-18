import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {CreateJobDto, JobDto} from '../models/job.dto';
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class JobService {

  public readonly jobs: string = '/jobs';
  public apiUrl: string = environment.urlAddress;

  constructor(private httpClient: HttpClient) { }

  public GetJobs(): Observable<JobDto[]> {
    return this.httpClient.get<JobDto[]>(this.apiUrl + this.jobs);
  }

  public GetJob(jobId: number): Observable<JobDto> {
    return this.httpClient.get<JobDto>(this.apiUrl + this.jobs + '/' + jobId);
  }

  public CreateJob(job: CreateJobDto): Observable<JobDto> {
    return this.httpClient.post<JobDto>(this.apiUrl + this.jobs, job);
  }
}
