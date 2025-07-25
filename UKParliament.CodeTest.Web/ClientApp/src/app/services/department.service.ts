import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { DepartmentViewModel } from '../models/department-view-model';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

/* This service is responsible for making HTTP requests to the API related to Department entities.
*/
export class DepartmentService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getAll(): Observable<DepartmentViewModel[]> {
    return this.http.get<DepartmentViewModel[]>(this.baseUrl + `api/department/all`)
      .pipe(
        catchError(error => {
          return throwError(() => error);
        })
      );
  }

}
