import { RouterModule } from '@angular/router';
import { setupRoutes } from './setup.routes';
import { NgModule } from '@angular/core';

@NgModule({
  imports: [ RouterModule.forChild(setupRoutes)],
  exports: [ RouterModule]
})
export class SetupRoutingModule { }