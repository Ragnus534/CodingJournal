import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit
{
  title = 'Coding Journal';

  constructor(private http: HttpClient,private accountService: AccountService){

  }

  ngOnInit(): void {
     this.setCurrentUser();
  }

  setCurrentUser(){
    const userJson = localStorage.getItem('user');
    
    const user: User =userJson !== null ? JSON.parse(userJson) : null;
    this.accountService.setCurrentUser(user);
  }

  

  // getUsers()
  // {
  //   this.http.get('https://localhost:7037/api/users').subscribe(response => {
  //     this.users = response;
  //     console.log(this.users);
  //   }, error => {
  //     console.log(error);
  //   })
  // }

}
