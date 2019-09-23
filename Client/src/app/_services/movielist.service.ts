import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { MovieList } from '@app/_models';


@Injectable({ providedIn: 'root' })
export class MovieListService {
    constructor(private http: HttpClient) { }

    getAllByUserId(id: number) {
      return this.http.get<MovieList[]>(`${environment.apiUrl}/movielists/` + id);
    }

    create(movieList: MovieList) {
        return this.http.post(`${environment.apiUrl}/movielists/create`, movieList);
    }

}
