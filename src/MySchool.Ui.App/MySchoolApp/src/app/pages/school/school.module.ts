import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SchoolListComponent } from './school-list/school-list.component';
import { SchoolFormComponent } from './school-form/school-form.component';
import { SharedModule } from "../../shared/shared.module";



@NgModule({
  declarations: [SchoolListComponent, SchoolFormComponent],
  imports: [
    CommonModule,SharedModule
  ]
})
export class SchoolModule { }
