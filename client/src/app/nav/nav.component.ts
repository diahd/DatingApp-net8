import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { CommonModule, TitleCasePipe } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule, CommonModule, BsDropdownModule, RouterLink, RouterLinkActive, TitleCasePipe],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  title = 'DatingApp';
  model: any = {};
  accountService = inject(AccountService);
  private router = inject(Router);
  private toastr = inject(ToastrService);
  //loggedIn = false;

  login(){
    this.accountService.login(this.model).subscribe({
      next: () =>  this.router.navigateByUrl('/members'),
      error: error => {
        console.log(error);
        this.toastr.error(error.error);
      }
    });
  }

  logout(){
    //this.loggedIn = false;
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
