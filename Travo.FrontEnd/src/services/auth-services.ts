/// <reference path="../lib/jquery/jquery.d.ts" />
/// <reference path="../lib/uikit/uikit.d.ts" />

import {Aurelia, inject} from 'aurelia-framework';
import {RestClient, Router} from 'rest-client';
import AuthClient from 'auth-client';
import config from 'travo-config';

@inject(Aurelia, RestClient, AuthClient)
export default class AuthServices {
    app: Aurelia;
    rest: RestClient;
    authClient: AuthClient;

    constructor(aurelia: Aurelia, restClient: RestClient, authClient: AuthClient) {
        this.app = aurelia;
        this.rest = restClient;
        this.authClient = authClient;
    }

    login(email: string, password: string) {
        let loginDTO = {
            grant_type: 'password',
            userName: email,
            password: password
        };

        return this.rest.postForm(Router.Token, loginDTO)
                .then(response => {
                    let token = response.access_token;

                    if (token != null) {
                        this.authClient.setAccessToken(token);
                        return null;
                    }

                    throw response;
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
        this.authClient.deleteAccessToken();
        this.app.setRoot('./dist/pages/landing-page/landing-page');
    }
}
