import { Injectable } from '@angular/core';
import { Department } from '@app/_models/department.model';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../environments/environment';

import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {
  formData: Department;
  list : any;

  constructor(private http:HttpClient) { }

  postDepartment(){
    return this.http.post(`${environment.apiUrl}/Departments`, this.formData)
    .pipe(
      catchError(this.errorHandler)
    );
  }

  putDepartment(){
    return this.http.put(`${environment.apiUrl}/Departments/${this.formData.DepartmentId}`, this.formData)
    .pipe(
      catchError(this.errorHandler)
    );
  }

  deleteDepartment(id:number){
    return this.http.delete(`${environment.apiUrl}/Departments/`+id)
    .pipe(
      catchError(this.errorHandler)
    );
  }

  reloadList(){
    this.http.get(`${environment.apiUrl}/Departments`)
    .toPromise()
    .then(res => this.list = res as Department[]);
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
