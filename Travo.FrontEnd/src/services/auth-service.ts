/// <reference path="../lib/jquery/jquery.d.ts" />

import {Aurelia, inject} from 'aurelia-framework';
import {HttpClient, json} from 'aurelia-fetch-client';
import config from 'travo-config';

// SRC: https://github.com/Foursails/sentry/blob/master/src/AuthService.js

@inject(Aurelia, HttpClient)
export default class AuthService {
    app: Aurelia;
    http: HttpClient;
    token: string = null;

    constructor(aurelia: Aurelia, httpClient: HttpClient) {
        this.http = httpClient;
        this.app = aurelia;

        // Get token from localStorage
        this.token = JSON.parse(localStorage[config.tokenName] || null);
    }

    login(email: string, password: string) {
        let loginDTO = {
            grant_type: 'password',
            userName: email,
            password: password
        };

        var loginResponse = {
            success: true,
            message: ""
        };

        return this.http.fetch(config.router.token, {
                    body: $.param(loginDTO),
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                })
                .then(response => response.json())
                .then(response => {
                    let token = response.access_token;
                    localStorage[config.tokenName] = JSON.stringify(token);
                    this.token = token;
                    this.app.setRoot('./dist/pages/travo-app/travo-app');
                    return loginResponse;
                })
                .catch(response => {
                    loginResponse.success = false;
                    switch (response.status) {
                        case 400:
                            loginResponse.message = "Wrong username or password.";
                            break;
                        case 500:
                            loginResponse.message = "The server is having difficulties right now, sorry.";
                            break;
                        default:
                            loginResponse.message = "Connection error, please try again.";
                            break;
                    }
                    return loginResponse;
                });
    }

    register(email: string, displayName: string, password: string) {
        let registerDTO = {
            email: email,
            displayName: displayName,
            password: password
        };

        var loginResponse = {
            success: true,
            message: ""
        };

        return this.http
            .fetch(config.router.register, {
                method: 'POST',
                body: json(registerDTO)
            }).then(response => { return loginResponse; })
            .catch(response => {
                loginResponse.success = false;
                switch (response.status) {
                    case 400:
                        loginResponse.message = "Wrong username or password.";
                        break;
                    case 500:
                        loginResponse.message = "The server is having difficulties right now, sorry.";
                        break;
                    default:
                        loginResponse.message = "Connection error, please try again.";
                        break;
                }
                return loginResponse;
            });
    }

    logOut() {
        localStorage[config.tokenName] = null;
        this.token = null;
        this.app.setRoot('./dist/pages/landing-page/landing-page');
    }

    isAuthenticated() {
        return this.token !== null;
    }
}
