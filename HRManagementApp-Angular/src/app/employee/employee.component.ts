import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../environments/environment';
import { EmployeeService } from '@app/_services';
import { Department } from '@app/_models/department.model';
import { Employee } from '@app/_models/employee.model';
import { Job } from '@app/_models/job.model';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styles: [
  ]
})

export class EmployeeComponent implements OnInit {
  dptList : Department[];
  mrgList : Employee[];
  jobsList : Job[];

  constructor(private http:HttpClient, public service: EmployeeService) { }

  ngOnInit(): void {
    this.resetForm();
    this.departmentList();
    this.managerList();
    this.jobList();
  }

  departmentList(){
    this.http.get(`${environment.apiUrl}/Departments`)
    .toPromise()
    .then(res => this.dptList = res as Department[]);
  }

  managerList(){
    this.http.get(`${environment.apiUrl}/Employees`)
    .toPromise()
    .then(res => this.mrgList = res as Employee[]);
  }

  jobList(){
    this.http.get(`${environment.apiUrl}/Jobs`)
    .toPromise()
    .then(res => this.jobsList = res as Job[]);
  }

  resetForm(form?:NgForm)
  {
    if(form!=null)
      form.form.reset();
    this.service.formData = {
      EmployeeId: 0,
      FirstName: '',
      LastName: '',
      Email: '',
      PhoneNumber: '',
      HireDate: new Date,
      Salary: 0,
      CommissionPCT: 0,
      ManagerId: 0,
      DepartmentId: 0,
      JobId: 0
    }
  }

  onSubmit(form: NgForm){
    if(this.service.formData.EmployeeId == 0)
      this.insert(form);
    else
      this.update(form);
  }

  insert(form: NgForm)
  {
    this.service.postEmployee().subscribe(
      res => {
        this.resetForm(form);
        Swal.fire('Great!', 'Information has been saved', 'success');
        this.service.reloadList();
      },
      err => {
        console.log(err);
      }
    );
  }

  update(form: NgForm)
  {
    this.service.putEmployee().subscribe(
      res => {
        this.resetForm(form);
        Swal.fire('Great!', 'Information has been updated', 'success');
        this.service.reloadList();
      },
      err => {
        console.log(err);
      }
    );
  }
}
