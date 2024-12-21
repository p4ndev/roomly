import { HttpErrorResponse, HttpResponseBase, HttpStatusCode } from '@angular/common/http';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { Component, inject, OnDestroy } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatInput } from '@angular/material/input';
import { MatIcon } from '@angular/material/icon';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

import { NotificationService } from '../../../service/notification.service';
import { InstallationService } from './installation.service';
import { InstallationRequest } from './installation.request';
import { ActionsEnum } from '../../../enum/actions.enum';
import { i18n } from '../../../data/i18n.const';

@Component({
  selector    : 'app-installation',
  styleUrl    : './installation.component.scss',
  templateUrl : './installation.component.html',
  imports     : [ ReactiveFormsModule, MatFormField, MatIcon, MatInput, MatButton, MatLabel ]
})
export class InstallationComponent implements OnDestroy{
  
  private subscription? : Subscription;  
  private readonly routerService         = inject(Router);
  private readonly formBuilder           = inject(FormBuilder);
  private readonly installationService   = inject(InstallationService);
  private readonly notificationService   = inject(NotificationService);
  
  formGroup = this.formBuilder
    .group({
      name      : ['', Validators.required],
      logotype  : ['', Validators.required]
    });

  ngOnDestroy() : void {
    if(this.subscription)
      this.subscription.unsubscribe();
  }
  
  onSubmit() : void {
    this.notificationService.notify(i18n.Installation.Submitting);
    
    this.subscription = this.installationService
      .add(this.formGroup.value as InstallationRequest)
        .subscribe({
          next  : this.onInstallationRegistered,
          error : this.onInstallationFailed
        });
  }

  onFileSelected(e : Event) : void {
    const fileInput = (e.target as HTMLInputElement);

    if (fileInput?.files?.length) {
      const reader = new FileReader();
      const logotype = fileInput.files[0];

      reader.onload = () => {
        if(logotype === undefined || logotype === null || !reader.result)
          return;
    
        this.formGroup.patchValue({ logotype: reader.result.toString() });
      };

      reader.readAsDataURL(logotype);
    }
  }

  private onInstallationRegistered = (res : HttpResponseBase) : void => {
    if(res.status === HttpStatusCode.Created)
      this.routerService.navigate(['setup', ActionsEnum.Access]);
  }

  private onInstallationFailed = (err : HttpErrorResponse) : void => {
    if (err.status === HttpStatusCode.BadRequest)
      this.notificationService.notify(i18n.Installation.ServerIssue);
  }
}