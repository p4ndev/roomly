import { environment } from "../environments/environment";
import { Injectable, signal } from "@angular/core";
import { RoleEnum } from "../enum/role.enum";

@Injectable({ providedIn: 'root' })
export class SessionService {
    
    logotype    = signal('');
    token       = signal('');
    isLogged    = signal(false);
    isConnected = signal(false);
    role        = signal(RoleEnum.None);

    constructor(){
        this.logotype.set(`${environment.api}/Setup/Startup/Logotype`);
    }

    initialize(model : any) : void{
        this.isLogged.set(true);
        this.token.set(model.token);
        this.role.set(RoleEnum[model.role as keyof typeof RoleEnum]);
    }

    disconnect() : void {
        this.token.set('');
        this.isLogged.set(false);
        this.isConnected.set(false);
        this.role.set(RoleEnum.None);
    }
}