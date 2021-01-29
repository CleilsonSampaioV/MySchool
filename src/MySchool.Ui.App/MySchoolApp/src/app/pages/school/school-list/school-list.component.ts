import { Component, OnInit } from '@angular/core';
import { BaseResourceListComponent } from 'src/app/shared/components/base-resource-list/base-resource-list.component';
import { School } from '../shared/school.model';
import { SchoolService } from '../shared/school.service';

@Component({
  selector: 'app-school-list',
  templateUrl: './school-list.component.html',
  styleUrls: ['./school-list.component.css']
})
export class SchoolListComponent extends BaseResourceListComponent<School> {

  constructor(private schoolService: SchoolService) {
    super(schoolService)
  }
}
