import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import config from 'travo-config';

@inject(HttpClient)
export class LandingPage {
    http: HttpClient;

    constructor(http: HttpClient) {
        this.http = http;
    }
}
