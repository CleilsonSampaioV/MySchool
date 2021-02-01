import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ClassListComponent } from "./class-list/class-list.component";
import { ClassFormComponent } from "./class-form/class-form.component";

// const routes: Routes = [
//   { path: ':id', component: ClassListComponent },
//   { path: ':id/new', component: ClassFormComponent },
//   { path: ':id/edit', component: ClassFormComponent }
// ];


const routes: Routes = [
  { path: ':id', component: ClassListComponent },
  { path: 'new/:id', component: ClassFormComponent },
  { path: 'edit/:school/:class', component: ClassFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClassRoutingModule { }
