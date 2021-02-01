import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./pages/school/school.module').then((m) => m.SchoolModule),
  },
  {
    path: 'escolas',
    loadChildren: () =>
      import('./pages/school/school.module').then((m) => m.SchoolModule),
  },
  {
    path: 'turmas',
    loadChildren: () =>
      import('./pages/class/class.module').then((m) => m.ClassModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
