/// <reference path="../lib/jquery/jquery.d.ts" />

import {Aurelia, inject} from 'aurelia-framework';
import {RestClient, Router} from 'rest-client';
import config from 'travo-config';

@inject(Aurelia, RestClient)
export default class AuthService {
    app: Aurelia;
    rest: RestClient;
    token: string = null;

    constructor(aurelia: Aurelia, restClient: RestClient) {
        this.app = aurelia;
        this.rest = restClient;

        // Get token from localStorage
        this.token = JSON.parse(localStorage[config.tokenName] || null);
    }

    login(email: string, password: string) {
        let loginDTO = {
            grant_type: 'password',
            userName: email,
            password: password
        };

        return this.rest.postForm(Router.RequestToken, loginDTO)
                .then(response => {
                    let token = response.access_token;
                    localStorage[config.tokenName] = JSON.stringify(token);
                    this.token = token;
                    this.app.setRoot('./dist/pages/travo-app/travo-app');
                    return null;
                });
    }

    register(email: string, displayName: string, password: string) {
        let registerDTO = {
            email: email,
            displayName: displayName,
            password: password
        };

        return this.rest.post(Router.Register, registerDTO);
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
