import { Injectable, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Guid } from 'guid-typescript';
import { Observable, throwError } from 'rxjs';
import { Class } from './class.model';
import { catchError, map } from 'rxjs/operators';
import { CommandResult } from 'src/app/shared/models/command-result.model';
import { URL_API } from 'src/app/app.api';

@Injectable({
  providedIn: 'root',
})
export class ClassService {
  public mainUrl = URL_API;

  urlBase: string = this.mainUrl + 'Class/';

  constructor(private http: HttpClient) {}

  getAllBySchoolId(id: Guid): Observable<Class[]> {
    return this.http
      .get(this.urlBase + `GetAllClassBySchoolId/${id}`)
      .pipe(catchError(this.handleError), map(this.jsonDataToClasses));
  }

  getAll(): Observable<Class[]> {
    return this.http
      .get(this.urlBase)
      .pipe(catchError(this.handleError), map(this.jsonDataToClasses));
  }

  getById(id: Guid): Observable<Class> {
    const url = `${this.urlBase}${id}`;
    debugger;
    return this.http
      .get(url)
      .pipe(catchError(this.handleError), map(this.jsonDataToClass));
  }

  create(schoolClass: Class): Observable<Class> {
    debugger;
    const url = this.urlBase + 'Create';
    return this.http
      .post(url, schoolClass)
      .pipe(catchError(this.handleError), map(this.jsonDataToClass));
  }

  update(schoolClass: Class): Observable<Class> {
    debugger;
    const url = this.urlBase + 'Update';
    return this.http.put(url, schoolClass).pipe(
      catchError(this.handleError),
      map(() => schoolClass)
    );
  }

  delete(id: Guid): Observable<any> {
    const url = this.urlBase + `Delete/${id}`;

    return this.http.delete(url).pipe(
      catchError(this.handleError),
      map(() => null)
    );
  }

  // PRIVATE METHODS
  private jsonDataToClass(jsonData: any): Class {
    debugger;
    if (jsonData.success) {
      return (jsonData.data as Class);
    }
  }

  private jsonDataToClasses(jsonData: CommandResult): Class[] {
    debugger;
    const schoolClasses: Class[] = [];
    if (jsonData.success) {
      jsonData.data.forEach((element) => schoolClasses.push(element as Class));
    }
    return schoolClasses;
  }

  private handleError(error: any): Observable<any> {
    debugger;
    console.log('ERRO NA REQUISIÇÃO ==>', error);
    return throwError(error);
  }
}
