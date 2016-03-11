import {Aurelia, inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-http-client';
import config from 'travo-config';

// SRC: https://github.com/Foursails/sentry/blob/master/src/AuthService.js

@inject(Aurelia, HttpClient)
export default class AuthService {
    app: Aurelia;
    http: HttpClient;
    session = null;

    constructor(aurelia: Aurelia, httpClient: HttpClient) {
        httpClient.configure(http => {
            http.withBaseUrl(config.baseUrl);
        });

        this.http = httpClient;
        this.app = aurelia;

        // Get token from localStorage
        this.session = JSON.parse(localStorage[config.tokenName] || null);
    }

    login(username: string, password: string) {
        this.http
            .post(config.loginUrl, { username, password })
            .then((response) => response.content)
            .then((session) => {

            // Save to localStorage and session
            localStorage[config.tokenName] = JSON.stringify(session);
            this.session = session;
            this.app.setRoot('app');
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
