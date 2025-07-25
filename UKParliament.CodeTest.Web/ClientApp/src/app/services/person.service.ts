import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PersonViewModel } from '../models/person-view-model';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

/* This service is responsible for making HTTP requests to the API related to Person entities.
*/
export class PersonService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  // Below is some sample code to help get you started calling the API
  getById(id: number): Observable<PersonViewModel> {
    return this.http.get<PersonViewModel>(this.baseUrl + `api/person/${id}`)
      .pipe(
        catchError(error => {
          return throwError(() => error);
        })
      );
  }

  getAll(): Observable<PersonViewModel[]> {
    return this.http.get<PersonViewModel[]>(this.baseUrl + `api/person/all`)
      .pipe(
        catchError(error => {
          return throwError(() => error);
        })
      );
  }

  save(person: PersonViewModel): Observable<PersonViewModel> {
    return this.http.post<PersonViewModel>(this.baseUrl + 'api/person', person)
      .pipe(
        catchError(error => {
          return throwError(() => error);
        })
      );
  }

}
