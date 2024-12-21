import { MatSnackBarModule } from '@angular/material/snack-bar';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AuthenticationService } from './authentication/authentication.service';
import { InstallationService } from './installation/installation.service';
import { SetupRoutingModule } from './setup-routing.module';
import { StartupService } from './startup/startup.service';

@NgModule({
  declarations  : [],
  providers     : [ StartupService, InstallationService, AuthenticationService ],
  imports       : [ CommonModule, SetupRoutingModule, MatSnackBarModule ]
})
export class SetupModule { }