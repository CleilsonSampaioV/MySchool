import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SchoolListComponent } from './school-list/school-list.component';
import { SchoolFormComponent } from './school-form/school-form.component';
import { SharedModule } from '../../shared/shared.module';
import { SchoolRoutingModule } from './school-routing.module';
import { IMaskModule } from 'angular-imask';
import { ClassRoutingModule } from '../class/class-routing.module';

@NgModule({
  declarations: [SchoolListComponent, SchoolFormComponent],
  imports: [
    CommonModule,
    SharedModule,
    SchoolRoutingModule,
    ClassRoutingModule,
    IMaskModule,
  ],
})
export class SchoolModule {}
