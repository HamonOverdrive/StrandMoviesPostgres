import { Component, OnInit } from '@angular/core';

import {Router, ActivatedRoute, Params} from '@angular/router';
import { AuthenticationService, AlertService, OMDBService, MovieListService } from '@app/_services';
import { MovieList, User, Movie } from '@app/_models';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.css']
})
export class MovieDetailComponent implements OnInit {
  movieLists: MovieList[];
  movie : Movie;
  currentUser: User;

  constructor(
      private omdbService: OMDBService,
      private route: ActivatedRoute,
      private movieListService: MovieListService) { }

  ngOnInit() {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    this.getByImdb();
    this.movieListService.getAllByUserId(this.currentUser.id).pipe(first()).subscribe(movieLists => {
      console.log(movieLists)
      this.movieLists = movieLists;
    });
  }

  getByImdb(): void {
    const imdbID = this.route.snapshot.paramMap.get('imdbID');
    this.omdbService.getByImdb(imdbID)
      .subscribe(movie =>{
        this.movie = movie
      });
  }

}
