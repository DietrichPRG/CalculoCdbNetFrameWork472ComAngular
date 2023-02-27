import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'cdb', loadChildren: () => import('./cdb/cdb.module').then(m => m.CdbModule) },
  { path: '', loadChildren: () => import('./cdb/cdb.module').then(m => m.CdbModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
