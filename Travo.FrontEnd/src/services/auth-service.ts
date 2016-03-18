/// <reference path="../lib/jquery/jquery.d.ts" />

import {Aurelia, inject} from 'aurelia-framework';
import {HttpClient, json} from 'aurelia-fetch-client';
import config from 'travo-config';

// SRC: https://github.com/Foursails/sentry/blob/master/src/AuthService.js

@inject(Aurelia, HttpClient)
export default class AuthService {
    app: Aurelia;
    http: HttpClient;
    session = null;

    constructor(aurelia: Aurelia, httpClient: HttpClient) {
        this.http = httpClient;
        this.app = aurelia;

        // Get token from localStorage
        this.session = JSON.parse(localStorage[config.tokenName] || null);
    }

    login(email: string, password: string) {
        let loginDTO = {
            grant_type: 'password',
            userName: email,
            password: password
        };

        return this.http.fetch(config.router.token, {
            body: $.param(loginDTO),
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            }
        });

            /* TODO
            Save token to localStorage and session
            localStorage[config.tokenName] = JSON.stringify(session);
            this.session = session;
            this.app.setRoot('app');
            */
    }

    register(email: string, displayName: string, password: string) {
        let registerDTO = {
            email: email,
            displayName: displayName,
            password: password
        };

        return this.http
            .fetch(config.router.register, {
                method: 'POST',
                body: json(registerDTO)
            });
    }

    logout() {
        localStorage[config.tokenName] = null;
        this.session = null;
        this.app.setRoot('login');
    }

    isAuthenticated() {
        return this.session !== null;
    }
}
