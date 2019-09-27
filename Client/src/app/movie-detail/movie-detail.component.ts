import { Component, OnInit } from '@angular/core';

import {Router, ActivatedRoute, Params} from '@angular/router';
import { AuthenticationService, AlertService, OMDBService } from '@app/_services';
import { MovieList, User, Movie } from '@app/_models';
@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css']
})
export class MovieDetailComponent implements OnInit {
  movie : Movie;
  constructor(
      private omdbService: OMDBService,
      private route: ActivatedRoute) { }

  ngOnInit() {
    this.getByImdb()
  }

  getByImdb(): void {
    const imdbID = this.route.snapshot.paramMap.get('imdbID');
    this.omdbService.getByImdb(imdbID)
      .subscribe(movie =>{
        this.movie = movie
      });
  }

}
