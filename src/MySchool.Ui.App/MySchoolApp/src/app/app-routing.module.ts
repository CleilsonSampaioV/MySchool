import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
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

  { path: '', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
