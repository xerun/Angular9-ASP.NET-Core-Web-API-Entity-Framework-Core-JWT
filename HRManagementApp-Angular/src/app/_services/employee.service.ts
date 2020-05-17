import { Injectable } from '@angular/core';
import { Employee } from '@app/_models/employee.model';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../environments/environment';

import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  formData: Employee;
  list : any;

  constructor(private http:HttpClient) { }

  postEmployee(){
    return this.http.post(`${environment.apiUrl}/Employees`, this.formData)
    .pipe(
      catchError(this.errorHandler)
    );
  }

  putEmployee(){
    return this.http.put(`${environment.apiUrl}/Employees/${this.formData.EmployeeId}`, this.formData)
    .pipe(
      catchError(this.errorHandler)
    );
  }

  deleteEmployee(id:number){
    return this.http.delete(`${environment.apiUrl}/Employees/`+id)
    .pipe(
      catchError(this.errorHandler)
    );
  }

  reloadList(){
    this.http.get(`${environment.apiUrl}/Employees`)
    .toPromise()
    .then(res => this.list = res as Employee[]);
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
