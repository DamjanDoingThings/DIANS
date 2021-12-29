import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { AuthenticationService } from '../authentication.service';
import { UserData } from '../models/UserData';
import { SignInData } from '../SignInData';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  isFormInvalid = false;
  areCredentialsInvalid = false;
  passwordsMatch: boolean = false;
  requiredFields: boolean = false;
  isValid: boolean = false;
  
  name: string = '';
  surname: string = '';
  email: string = '';
  confirm: string = '';
  password: string = '';


  constructor(private router: Router, private http: HttpClient) { }

  ngOnInit(): void {
  }


  onSubmit(signInForm: NgForm) {
    if (this.isValid == false) {
      return;
    }

    this.http.post<UserData>(environment.apiUrl+"/User/Register", 
    {
      name: this.name,
      surname: this.surname,
      email: this.email,
      password: this.password
    })
    .subscribe((x) => {
      alert("Успешна регистрација!");
      this.router.navigate(["/log-in"]);
    });

  }

  checkSame(pass: string) {
    if (this.confirm.length == 0) {
      this.passwordsMatch = false;
      this.isValid = this.requiredFields && this.passwordsMatch;
      return;
    }
    
    this.passwordsMatch = this.confirm === this.password; 
  }

  checkNotEmpty(v: string) {
    this.requiredFields = true;
      if (this.name.length == 0 ||
          this.surname.length == 0 ||
          this.email.length == 0
      ) {
        this.requiredFields = false;
        this.isValid = this.requiredFields && this.passwordsMatch;
        return;
      }
   
    this.isValid = this.requiredFields && this.passwordsMatch;
  }

}
