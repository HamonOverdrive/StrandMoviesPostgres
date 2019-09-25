import { Component, OnInit } from '@angular/core';
import { Router, NavigationExtras } from '@angular/router';
import { AuthenticationService, AlertService, OMDBService } from '@app/_services';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  loading = false;
  submitted = false;

  constructor(
    private authenticationService: AuthenticationService,
    private omdbService: OMDBService,
    private router: Router,
    private alertService: AlertService,
    private formBuilder: FormBuilder,
    ) { }

  ngOnInit() {

  }

  onSubmit(value: any) {
    this.submitted = true;

    // reset alerts on submit
    this.alertService.clear();

    this.loading = true;
    let convertedParam = value.toLowerCase().split(' ').join('+');
    let navigationExtras: NavigationExtras = {
      queryParams: { 'input': convertedParam}
    }
    this.router.navigate(['/search'], navigationExtras);
    // this.omdbService.movieSearchQuery()
    // .pipe(first())
    // .subscribe(
    //     data => {
    //         this.alertService.success('Strand Created', true);
    //         this.router.navigate(['/search'], navigationExtras);
    //     },
    //     error => {
    //         this.alertService.error(error);
    //         this.loading = false;
    //     });
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
}

}
