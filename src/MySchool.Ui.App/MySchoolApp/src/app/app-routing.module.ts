import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  // { path: 'entries', loadChildren: () => import('./pages/entries/entries.module').then(m => m.EntriesModule) },
  { path: 'escolas', loadChildren: () => import('./pages/school/school.module').then(m => m.SchoolModule) },
  // { path: 'reports', loadChildren: () => import('./pages/reports/reports.module').then(m => m.ReportsModule) },

  { path: '', redirectTo: '', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
