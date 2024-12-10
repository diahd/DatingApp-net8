import { Component, OnInit, inject } from '@angular/core';
import { RegisterComponent } from "../register/register.component";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RegisterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent /*implements OnInit*/{
  
  registerMode = false;
  http = inject(HttpClient);
  users: any;

  // ngOnInit(): void {
  //   this.getUsers();
  // }

  registerToggle(){
    this.registerMode = !this.registerMode;
  }

  getUsers(){
    this.http.get('https://localhost:5164/api/Users').subscribe({
      next: response =>  {
        this.users = response;
        console.log('ini', response)
      },
      error: error => console.log(error),
      complete: () => console.log('Request has completed', this.users)
    });
  }

  cancelRegisterMode(event: boolean){
    this.registerMode = event;
  }

}
