import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

import { AuthenticationResponse } from './authentication.response';
import { environment } from '../../../environments/environment';

@Injectable()
export class AuthenticationService {

    private readonly http       = inject(HttpClient);
    private readonly endpoint   = `${environment.api}/setup/authentication`;

    connect = (password : string) => {
        const headers = new HttpHeaders({ 'password': password.toString() });
        return this.http.get<AuthenticationResponse>(this.endpoint, { headers, observe: 'response' });
    };
}