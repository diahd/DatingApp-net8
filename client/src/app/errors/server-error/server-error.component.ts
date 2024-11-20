import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-server-error',
  standalone: true,
  imports: [],
  templateUrl: './server-error.component.html',
  styleUrl: './server-error.component.css'
})
export class ServerErrorComponent {
  error: any;

  //navigation extras only can be accessed here
  constructor(router: Router) {
    const navigation = router.getCurrentNavigation();
    console.log('server-error1',navigation);
    this.error = navigation?.extras?.state?.['error'];
    console.log('server-error2',this.error);
  }
  
}