import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AuthenticationService } from './_services';
import { User } from './_models/user.model';

@Component({
  selector: 'app',
  templateUrl: './app.component.html'
})
export class AppComponent {  
  currentUser: User;
  searchMenu: FormGroup;

  constructor(
      private formBuilder: FormBuilder,
      private router: Router,
      private authenticationService: AuthenticationService
  ) {
      this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit() {
    this.searchMenu = this.formBuilder.group({
      search: ['', Validators.required]
    });
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }
}