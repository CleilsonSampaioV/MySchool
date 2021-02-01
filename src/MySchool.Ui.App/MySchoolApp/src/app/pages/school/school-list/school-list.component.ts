import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { BaseResourceListComponent } from 'src/app/shared/components/base-resource-list/base-resource-list.component';
import { School } from '../shared/school.model';
import { SchoolService } from '../shared/school.service';

@Component({
  selector: 'app-school-list',
  templateUrl: './school-list.component.html',
  styleUrls: ['./school-list.component.css']
})
export class SchoolListComponent extends BaseResourceListComponent<School> {

  constructor(private schoolService: SchoolService, private router: Router) {
    super(schoolService)
  }

  actionsForCreateNewClass(id: Guid): void {
    debugger;
    this.router.navigateByUrl('turmas', { skipLocationChange: true })
      .then(() => this.router.navigate([`turmas/${id}`]));
  }
}
