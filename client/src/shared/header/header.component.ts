import { Component, computed, inject, input, OnDestroy, OnInit, signal, ViewEncapsulation } from '@angular/core';
import {BreakpointObserver, Breakpoints, BreakpointState} from '@angular/cdk/layout';
import {MatGridListModule} from '@angular/material/grid-list';
import { NgIf } from '@angular/common';
import { Subscription } from 'rxjs';

import { AdministratorMenuComponent } from '../menu-roles/administrator-menu.component';
import { CoordinatorMenuComponent } from '../menu-roles/coordinator-menu.component';
import { ViewerMenuComponent } from '../menu-roles/viewer-menu.component';
import { SessionService } from '../../service/session.service';
import { RoleEnum } from '../../enum/role.enum';

@Component({
  selector      : 'app-header',
  encapsulation : ViewEncapsulation.None,
  styleUrl      : './header.component.scss',
  templateUrl   : './header.component.html',
  imports       : [ ViewerMenuComponent, CoordinatorMenuComponent, AdministratorMenuComponent, MatGridListModule, NgIf ],
})
export class HeaderComponent implements OnInit, OnDestroy {
  
  private sub? : Subscription;
  private readonly sessionService       = inject(SessionService);
  private readonly breakpointService    = inject(BreakpointObserver);

  private isSmallScreen                 = signal(false);
  role                                  = input<RoleEnum>(RoleEnum.None);
  leftColumns                           = computed(() => this.isSmallScreen() ? 3 : 1);
  rightColumns                          = computed(() => this.isSmallScreen() ? 3 : 2);

  constructor(){ }

  ngOnInit(): void {
    this.sub = this.breakpointService
      .observe([Breakpoints.XSmall, Breakpoints.Small])
      .subscribe((res : BreakpointState) => {
        this.isSmallScreen.set(res.matches);
      });
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

  get isAvailable() : boolean{
    return (this.role() !== RoleEnum.None);
  }

  get logoSource() : string{
    return this.sessionService.logotype();
  }

  get userRoles() : typeof RoleEnum{
    return RoleEnum;
  }
}