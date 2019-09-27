import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AlertService, UserService, AuthenticationService, MovieListService, MovieService } from '../_services';
import { MovieList, User, Movie } from '@app/_models';
import { Location } from '@angular/common';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-strand-details',
  templateUrl: './strand-details.component.html',
  styleUrls: ['./strand-details.component.css']
})
export class StrandDetailsComponent implements OnInit {
  strand : MovieList;
  movies : Movie[];
  constructor(
    private route: ActivatedRoute,
    private movieListService: MovieListService,
    private movieService: MovieService,
    private alertService: AlertService,
    private location: Location
  ) { }

  ngOnInit() {
    this.getById()
  }
  deleteMovie(id: number) {
    this.movieService.delete(id).pipe(first()).subscribe(() => {
        this.getById()
    });
}

  getById(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.movieListService.getById(id)
      .subscribe(strand =>{
        console.log(strand)
        this.strand = strand
      });
  }

  goBack(): void {
    this.location.back();
  }

}
