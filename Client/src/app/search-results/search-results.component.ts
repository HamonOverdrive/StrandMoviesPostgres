import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MovieList, User, MovieDto } from '@app/_models';
import {Router, ActivatedRoute, Params} from '@angular/router';
import { AuthenticationService, AlertService, OMDBService } from '@app/_services';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.css']
})
export class SearchResultsComponent implements OnInit {

  moviedtos : MovieDto[];
  searchInput: string;
  constructor(private activatedRoute: ActivatedRoute, private omdbService: OMDBService) { }

  ngOnInit() {
    this.activatedRoute.queryParams.subscribe(params => {
      const inputParam = params['input'];
      console.log(inputParam);
      this.searchInput = inputParam;
    });

    this.getSearchMovieQuery();
  }

  getSearchMovieQuery(): void {
    this.omdbService.movieSearchQuery()
        .subscribe(movies => this.moviedtos = movies);
  }

}
