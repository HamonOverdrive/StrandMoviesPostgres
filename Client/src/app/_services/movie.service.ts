import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { environment } from '@environments/environment';
import { User, Movie } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class MovieService {
    constructor(private http: HttpClient) { }

    getByTitle() {
        return this.http.post(`${environment.apiUrl}/movies/kara`, null);
    }

  //   getByTitle() {
  //     return this.http.post(`${environment.apiUrl}/users/register`, user);
  // }
  getAllFromCurrentStrand(id: number){
    return this.http.get<Movie[]>(`${environment.apiUrl}/movies/` + id);
  }

  create(movie : Movie, listId: string){
    let params = new HttpParams()
      .set('listId', listId);


    return this.http.post(`${environment.apiUrl}/movies/`,movie, { params });
  }

  delete(id: number) {
    return this.http.delete(`${environment.apiUrl}/movies/` + id);
  }


}
