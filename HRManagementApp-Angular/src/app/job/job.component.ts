import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http'
import { JobService } from '@app/_services';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styles: [
  ]
})

export class JobComponent implements OnInit {

  constructor(private http:HttpClient, public service: JobService) { }

  ngOnInit(): void {
    this.resetForm();
  }

  resetForm(form?:NgForm)
  {
    if(form!=null)
      form.form.reset();
    this.service.formData = {
      JobId: 0,
      JobTitle: '',
      MinSalary: 0,
      MaxSalary: 0
    }
  }

  onSubmit(form: NgForm){
    if(this.service.formData.JobId == 0)
      this.insert(form);
    else
      this.update(form);
  }

  insert(form: NgForm)
  {
    this.service.postJob().subscribe(
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
    this.service.putJob().subscribe(
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
