import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

import { environment } from '../../../environments/environment';
import { InstallationRequest } from './installation.request';

@Injectable()
export class InstallationService {
    
    private readonly http       = inject(HttpClient);
    private readonly endpoint   = `${environment.api}/setup/installation`;

    add = (input : InstallationRequest) => 
        this.http.post(this.endpoint, input, { observe: 'response' });
}