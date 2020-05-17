import { Injectable } from '@angular/core';
import { Job } from '@app/_models/job.model';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../environments/environment';

import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class JobService {
  formData: Job;
  list : any;

  constructor(private http:HttpClient) { }

  postJob(){
    return this.http.post(`${environment.apiUrl}/Jobs`, this.formData)
    .pipe(
      catchError(this.errorHandler)
    );
  }

  putJob(){
    return this.http.put(`${environment.apiUrl}/Jobs/${this.formData.JobId}`, this.formData)
    .pipe(
      catchError(this.errorHandler)
    );
  }

  deleteJob(id:number){
    return this.http.delete(`${environment.apiUrl}/Jobs/`+id)
    .pipe(
      catchError(this.errorHandler)
    );
  }

  reloadList(){
    this.http.get(`${environment.apiUrl}/Jobs`)
    .toPromise()
    .then(res => this.list = res as Job[]);
  }

  errorHandler(error) {
    let errorMessage = '';
    if(error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
 }
}
