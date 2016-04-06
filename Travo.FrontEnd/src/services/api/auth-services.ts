/// <reference path="../../lib/jquery/jquery.d.ts" />
/// <reference path="../../lib/uikit/uikit.d.ts" />

import {Aurelia, inject} from 'aurelia-framework';
import {RestClient, Router} from 'services/rest-client';

@inject(Aurelia, RestClient)
export default class AuthServices {
    app: Aurelia;
    rest: RestClient;

    constructor(aurelia: Aurelia, restClient: RestClient) {
        this.app = aurelia;
        this.rest = restClient;
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
                        return token;
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
}
