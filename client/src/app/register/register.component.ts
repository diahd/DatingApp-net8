import { Component, inject, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  //cuma buat angular 17.3 ke atas
  //@Input() usersFromHomeComponent: any;
  usersFromHomeComponent = input.required<any>();
  //@Output() cancelRegister = new EventEmitter();
  cancelRegister = output<boolean>();
  model: any = {};
  private accountService = inject(AccountService);

  register(){
    
    this.accountService.register(this.model).subscribe({
      next: response => {
        console.log('next', this.model);
        console.log('response', response)
        this.cancel();
      },
      error: error => console.log(error)
    });
  }

  cancel(){
    console.log('cancelled');
    this.cancelRegister.emit(false);
  }
}
