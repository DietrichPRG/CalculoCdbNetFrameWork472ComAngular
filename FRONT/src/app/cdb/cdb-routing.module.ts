import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CdbComponent } from './cdb.component';

const routes: Routes = [{ path: '', component: CdbComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CdbRoutingModule { }
