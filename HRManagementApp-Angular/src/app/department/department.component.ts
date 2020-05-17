import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../environments/environment';
import { DepartmentService } from '@app/_services';
import { Employee } from '@app/_models/employee.model';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styles: [
  ]
})

export class DepartmentComponent implements OnInit {
  empList : Employee[];

  constructor(private http:HttpClient, public service: DepartmentService) { }

  ngOnInit(): void {
    this.resetForm();
    this.employeeList();
  }

  employeeList(){
    this.http.get(`${environment.apiUrl}/Employees`)
    .toPromise()
    .then(res => this.empList = res as Employee[]);
  }

  resetForm(form?:NgForm)
  {
    if(form!=null)
      form.form.reset();
    this.service.formData = {
      DepartmentId: 0,
      DepartmentName: '',
      ManagerId: 0
    }
  }

  onSubmit(form: NgForm){
    if(this.service.formData.DepartmentId == 0)
      this.insert(form);
    else
      this.update(form);
  }

  insert(form: NgForm)
  {
    this.service.postDepartment().subscribe(
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
    this.service.putDepartment().subscribe(
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
