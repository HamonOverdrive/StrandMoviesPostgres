import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '@app/_services';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router,
    ) { }

  ngOnInit() {
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
}

}
