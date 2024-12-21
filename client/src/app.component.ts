import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NgClass } from '@angular/common';

import { HeaderComponent } from './shared/header/header.component';
import { SessionService } from './service/session.service';
import { RoleEnum } from './enum/role.enum';

@Component({
  selector  : 'app-root',
  imports   : [RouterOutlet, NgClass, HeaderComponent],
  styles    : `
    main{
      width: 100vw;
      height: 100vh;
    }
  `,
  template  : `
    <main [ngClass]="isLogged ? null : 'fully-centered'">
      <app-header [role]="userRole"  />
      <router-outlet />
    </main>
  `
})
export class AppComponent {
  
  private readonly sessionService = inject(SessionService);

  get isLogged() : boolean{
    return this.sessionService.isLogged();
  }

  get userRole() : RoleEnum{
    return this.sessionService.role();
  }
}