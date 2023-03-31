import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Signup } from 'src/app/shared/models/signup';
import { DataService } from 'src/app/shared/services/data.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent {

  constructor(private dataService:DataService, private router:Router ) {}

  signup={
    email:'',
    password:'',
    confirmPassword:''
  };
  
  arePasswordsSame:boolean=false;
  signupForm:any;
  responseData:any;

  submitForm(signupForm:NgForm){
    this.signupForm=signupForm;

    let newUser:Signup={
      email:this.signup.email,
      password:this.signup.password
    };

    this.dataService.signupUser(newUser).subscribe(
      responseData=>{
        this.handleResponse(responseData);
      }
    );

    this.signup.email=''; 
    this.signup.password='';
    this.signup.confirmPassword='';
    signupForm.reset();

    if(this.responseData!=null){
      this.router.navigate(['/auth/login']);
    }
    else{
      alert("No response data!");
    }
    
  }

  hasMatched(password:string, confirmPassword:string):boolean
  {
    if(password===confirmPassword){
      this.arePasswordsSame=true;
    }
    else{
      this.arePasswordsSame=false;
    }
    return this.arePasswordsSame;
  }

  handleResponse(responseData:any){
    this.responseData=responseData;
  }

}
