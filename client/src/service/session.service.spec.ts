import { RoleEnum } from "../enum/role.enum";
import { signal } from "@angular/core";

export class MockSessionService {
    logotype    = signal('')
    token       = signal('')
    isLogged    = signal(false);
    role        = signal(RoleEnum.None);
    initialize  = jasmine.createSpy('initialize');
}