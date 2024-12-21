import { MatProgressSpinner } from '@angular/material/progress-spinner';
import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

import { NotificationService } from '../../../service/notification.service';
import { ActionsEnum } from '../../../enum/actions.enum';
import { StartupService } from './startup.service';
import { i18n } from '../../../data/i18n.const';

@Component({
  selector    : 'app-startup',
  template    : `<mat-spinner />`,
  imports     : [MatProgressSpinner]
})
export class StartupComponent implements OnInit, OnDestroy {
  
  private subscription? : Subscription;
  private readonly routerService          = inject(Router);
  private readonly startupService         = inject(StartupService);
  private readonly notificationService    = inject(NotificationService);

  ngOnInit() : void {
    this.notificationService.notify(i18n.StartUp.LoadingConfiguration);

    this.subscription = this.startupService
      .load()
        .subscribe({
          next  : this.onConfigurationFound,
          error : this.onConfigurationMissing
        });
  }

  ngOnDestroy(): void {
    if(this.subscription)
      this.subscription.unsubscribe();
  }

  private onConfigurationFound = () : void => {    
    this.notificationService.close();
    this.routerService.navigate(['setup', ActionsEnum.Auth]);
  }

  private onConfigurationMissing = () : void => {
    this.notificationService.notify(i18n.StartUp.MissingConfiguration);
    this.routerService.navigate(['setup', ActionsEnum.Install]);
  }
}
