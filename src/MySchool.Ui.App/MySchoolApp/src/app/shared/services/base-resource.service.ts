import { BaseResourceModel } from '../models/base-resource.model';

import { Injector } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { Guid } from 'guid-typescript';
import { CommandResult } from '../models/command-result.model';
import { URL_API } from 'src/app/app.api';

export abstract class BaseResourceService<T extends BaseResourceModel> {
  protected http: HttpClient;
  private urlBase = URL_API;

  constructor(
    protected apiPath: string,
    protected injector: Injector,
    protected jsonDataToResourceFn: (jsonData: any) => T
  ) {
    this.http = injector.get(HttpClient);
  }

  public getUrl(): string {
    return this.urlBase + this.apiPath;
  }

  getAll(): Observable<T[]> {
    return this.http
      .get(this.urlBase + this.apiPath)
      .pipe(
        map(this.jsonDataToResources.bind(this)),
        catchError(this.handleError)
      );
  }

  getById(id: Guid): Observable<T> {
    const url = `${this.urlBase + this.apiPath}/${id}`;

    return this.http
      .get(url)
      .pipe(
        map(this.jsonDataToResource.bind(this)),
        catchError(this.handleError)
      );
  }

  create(resource: T): Observable<T> {
    debugger;
    return this.http
      .post(this.urlBase + this.apiPath + '/Create', resource)
      .pipe(
        map(this.jsonDataToResource.bind(this)),
        catchError(this.handleError)
      );

    // return this.http.post(this.urlBase + this.apiPath, resource).pipe(
    //   map((valor: any) => valor),
    //   catchError(this.handleError));
  }

  update(resource: T): Observable<T> {
    const url = `${this.urlBase + this.apiPath + '/Update'}`;

    return this.http.put(url, resource).pipe(
      map(() => resource),
      catchError(this.handleError)
    );
  }

  delete(id: Guid): Observable<any> {
    const url = `${this.urlBase + this.apiPath + '/Delete'}/${id}`;

    return this.http.delete(url).pipe(
      map(() => null),
      catchError(this.handleError)
    );
  }

  // PROTECTED METHODS

  protected jsonDataToResources(jsonData: CommandResult): T[] {
    debugger;
    const resources: T[] = [];
    if (jsonData.success) {
      jsonData.data.forEach((element) =>
        resources.push(this.jsonDataToResourceFn(element))
      );
    }
    return resources;
  }

  protected jsonDataToResource(jsonData: CommandResult): T {
    debugger;
    return this.jsonDataToResourceFn(jsonData.data);
  }

  protected handleError(error: any): Observable<any> {
    console.log('ERRO NA REQUISIÇÃO => ', error);
    return throwError(error);
  }
}
