/// <reference path="./lib/jquery/jquery.d.ts" />

import {inject} from 'aurelia-framework';
import {HttpClient, json} from 'aurelia-fetch-client';
import AuthClient from 'auth-client';
import config from 'travo-config';

@inject(HttpClient, AuthClient)
export class RestClient {
    http: HttpClient;
    authClient: AuthClient;

    constructor(httpClient: HttpClient, authClient: AuthClient) {
        this.authClient = authClient;

        httpClient.configure(httpconfig => {
            httpconfig
                .withBaseUrl(config.baseUrl)
                .withDefaults({
                    mode: 'cors',
                    headers: {
                        'X-Requested-With': 'Fetch'
                    }
                });
        });
        this.http = httpClient;
    }

    get(path: string) {
        return this.request('GET', path);
    }

    post(path: string, body: Object) {
        return this.request('POST', path, body);
    }

    request(method: string, path: string, body?: Object) {
        let requestOptions = {
            method: method,
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: {}
        }

        if (this.authClient.isAuthenticated()) {
            requestOptions.headers['Authorization'] = "Bearer " + this.authClient.getAccessToken();
        }

        if (typeof body === 'object') {
            requestOptions.body = json(body);
        }

        return this.http.fetch(path, requestOptions).then(response => {
            if (response.status >= 200 && response.status < 400) {
                return response.json().catch(error => null);
            }

            // Log the error to console
            if (response.status == 400) response.json().then(e => console.log("Server responded with status code 400.", e));
            else console.log("Server responded with status code: " + response.status);

            throw response;
        });
    }

    // Custom handler for x-www-form-url-encoded
    postForm(path: string, body: Object) {
        let requestOptions = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: {}
        }

        if (typeof body === 'object') {
            requestOptions.body = jQuery.param(body);
        }

        return this.http.fetch(path, requestOptions).then(response => {
            if (response.status >= 200 && response.status < 400) {
                return response.json().catch(error => null);
            }

            // Log the error to console
            if (response.status == 400) response.json().then(e => console.log("Server responded with status code 400.", e));
            else console.log("Server responded with status code: " + response.status);

            throw response;
        });
    }
}

export class Router {
    public static Register = 'user/register';
    public static Token ='user/token';
    public static TeamsWithBoards = 'teams/withBoards';
}
