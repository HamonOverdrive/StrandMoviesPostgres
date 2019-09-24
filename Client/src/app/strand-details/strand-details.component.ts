import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AlertService, UserService, AuthenticationService, MovieListService } from '../_services';

@Component({
  selector: 'app-strand-details',
  templateUrl: './strand-details.component.html',
  styleUrls: ['./strand-details.component.css']
})
export class StrandDetailsComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private movieListService: MovieListService,
    private alertService: AlertService
  ) { }

  ngOnInit() {
  }

}
