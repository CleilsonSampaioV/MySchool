import { Injectable, Injector } from '@angular/core';
import { School } from './school.model';
import { BaseResourceService } from '../../../shared/services/base-resource.service';


@Injectable({
  providedIn: 'root'
})
export class SchoolService extends BaseResourceService<School> {

  constructor(protected injector: Injector) {
    super("school", injector, School.fromJson);
  }


  
}
