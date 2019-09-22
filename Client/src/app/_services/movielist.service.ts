import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { MovieList } from '@app/_models';


@Injectable({ providedIn: 'root' })
export class MovieListService {
    constructor(private http: HttpClient) { }

    create(movieList: MovieList) {
        return this.http.post(`${environment.apiUrl}/movielists/create`, movieList);
    }


}
