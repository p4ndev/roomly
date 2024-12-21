import { HttpErrorResponse, HttpResponse, HttpStatusCode } from '@angular/common/http';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { Component, inject, OnInit } from '@angular/core';
import { MatButton } from '@angular/material/button';
import { MatInput } from '@angular/material/input';
import { Router } from '@angular/router';

import { NotificationService } from '../../../service/notification.service';
import { AuthenticationResponse } from './authentication.response';
import { AuthenticationService } from './authentication.service';
import { SessionService } from '../../../service/session.service';

@Component({
  selector    : 'app-authentication',
  styleUrl    : './authentication.component.scss',
  templateUrl : './authentication.component.html',
  imports     : [ ReactiveFormsModule, MatFormField, MatLabel, MatInput, MatButton ],
})
export class AuthenticationComponent implements OnInit {
  
  private readonly router               = inject(Router);
  private readonly formBuilder          = inject(FormBuilder);
  private readonly sessionService       = inject(SessionService);
  private readonly notificationService  = inject(NotificationService);
  private readonly authService          = inject(AuthenticationService);
  
  formGroup = this.formBuilder
    .group({
      password: ['', Validators.required]
    });
  
  get logotypeSource() : string{
    return this.sessionService.logotype();
  }

  ngOnInit() : void {
    if(this.sessionService.isLogged())
      this.redirect();
  }

  redirect() : void{ 
    this.router.navigate(['dashboard']);
  }

  onSubmit() : void {
    this.authService
      .connect(this.formGroup.controls.password.value as string)
        .subscribe({
          next  : this.onConnectionSuccess,
          error : this.onConnectionFail
        });
  }

  onConnectionSuccess = (res : HttpResponse<AuthenticationResponse>) => {
    if(res.status !== HttpStatusCode.Ok || !res.body)
      return;

    this.notificationService.notify('Welcome :)');
    this.sessionService.initialize(res.body!);
    this.redirect();
  };

  onConnectionFail = (err : HttpErrorResponse) => {
    if(err.status === HttpStatusCode.NotFound){
      this.notificationService.notify('User has not found.');
      return;
    }

    this.notificationService.notify('Server was not able to process.');
  }
}