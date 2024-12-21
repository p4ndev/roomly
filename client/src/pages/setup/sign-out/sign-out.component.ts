import { Component, inject, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { SessionService } from "../../../service/session.service";
import { ActionsEnum } from "../../../enum/actions.enum";

@Component({
    selector  : 'app-sign-out',
    template  : ``,
  })
  export class SignOutComponent implements OnInit {
  
    private readonly routerService  = inject(Router);
    private readonly sessionService = inject(SessionService);

    ngOnInit() : void {
      this.sessionService.disconnect();
      this.routerService.navigate(['setup', ActionsEnum.Auth]);
    }
}