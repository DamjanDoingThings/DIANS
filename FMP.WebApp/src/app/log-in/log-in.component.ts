import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SignInData } from 'src/app/SignInData';
import { AuthenticationService } from 'src/app/authentication.service'
import { HttpClient, HttpResponse } from '@angular/common/http';
import { UserData } from '../models/UserData';
import { environment } from 'src/environments/environment';





@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.scss']
})

export class LoginComponent {



  isFormInvalid = false;
  areCredentialsInvalid = false;
  username: string = '';
  password: string = '';

  constructor(private authenticationService: AuthenticationService,
    private router: Router, private http: HttpClient) { }

  ngOnInit() { }

  onSubmit() {
    
    console.log("login");
    this.http.post<UserData>(environment.apiUrl+"/User/Login",
      {
        username: this.username,
        password: this.password
      })
      .subscribe(
        (x) => {
        console.log(x);
          this.router.navigate(["/search"]);
       
      },
      (error) => {
        alert("Погрешни податоци за најава");
      });
  }

}


