import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatProgressSpinner } from '@angular/material/progress-spinner';
import { Component, computed, inject, resource } from '@angular/core';
import { MatCheckbox } from '@angular/material/checkbox';
import { MatButton } from '@angular/material/button';
import { Router } from '@angular/router';

import { AccessItemComponent } from '../access-item/access-item.component';
import { environment } from '../../../environments/environment';
import { ActionsEnum } from '../../../enum/actions.enum';
import { PasswordModel } from './access.model';

@Component({
  selector    : 'app-access',
  templateUrl : './access.component.html',
  imports     : [ ReactiveFormsModule, AccessItemComponent, MatProgressSpinner, MatCheckbox, MatButton ]
})
export class AccessComponent {
  
  private readonly routerService  = inject(Router);
  private readonly formBuilder    = inject(FormBuilder);
  
  apiResponse = resource({
    loader: async () : Promise<PasswordModel> => {

      const response = await fetch(`${environment.api}/setup/access`);

      if(!response.ok)
        throw new Error('Unable to load passwords.');

      return ((await response.json()) as PasswordModel);
    }
  });

  model = computed(() => this.apiResponse.value() ?? undefined);

  formGroup = this.formBuilder
    .group({
      consent : [false, Validators.required]
    });

  get Consent() : boolean | null{
    return this.formGroup.controls.consent.value;
  }

  isEligible = () : boolean => 
    !this.formGroup.valid || !this.Consent;

  onSubmit() : void {
    this.routerService.navigate(['setup', ActionsEnum.Auth]);
  }
}