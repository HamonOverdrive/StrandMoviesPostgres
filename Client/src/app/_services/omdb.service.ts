import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { MovieList, Movie, MovieDto } from '@app/_models';


@Injectable({ providedIn: 'root' })
export class OMDBService {
    constructor(private http: HttpClient) { }

    movieSearchQuery(){
      console.log("hit")
      return this.http.get<MovieDto[]>(`${environment.apiUrl}/search/`);
    }


}
