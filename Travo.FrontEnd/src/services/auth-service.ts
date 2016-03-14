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
        let loginVM = {
            email: email,
            password: password
        };

        return this.http
            .fetch(config.router.login, {
                method: 'POST',
                body: json(loginVM)
            })
            .then(response => response.json())
            .then(anything => console.log(anything))
            .catch(error => {
                console.log(error);
            });

            /* TODO
            Save token to localStorage and session
            localStorage[config.tokenName] = JSON.stringify(session);
            this.session = session;
            this.app.setRoot('app');
            */
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
