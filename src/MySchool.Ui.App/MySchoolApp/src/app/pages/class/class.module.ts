import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClassListComponent } from './class-list/class-list.component';
import { ClassFormComponent } from './class-form/class-form.component';
import { SharedModule } from '../../shared/shared.module';
import { ClassRoutingModule } from './class-routing.module';
import { IMaskModule } from 'angular-imask';

@NgModule({
  declarations: [ClassListComponent, ClassFormComponent],
  imports: [CommonModule, SharedModule, ClassRoutingModule, IMaskModule],
})
export class ClassModule {}
