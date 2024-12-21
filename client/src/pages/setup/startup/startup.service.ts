import { environment } from "../../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class StartupService {    
    private readonly endpoint = `${environment.api}/setup/startup`;

    constructor(private http : HttpClient) { }

    load = () => this.http.get(this.endpoint);
}