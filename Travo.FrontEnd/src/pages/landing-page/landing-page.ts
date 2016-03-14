import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import AuthService from 'services/auth-service';
import config from 'travo-config';

@inject(AuthService, HttpClient)
export class LandingPage {
    auth: AuthService;
    http: HttpClient;

    // User inputs (bound in viewmodel)
    loginEmail: string = "";
    loginPassword: string = "";
    registerEmail: string = "";
    registerUsername: string = "";
    registerPassword: string = "";

    constructor(authService: AuthService, http: HttpClient) {
        this.auth = authService;

        http.configure(httpconfig => {
            httpconfig
                .withBaseUrl(config.baseUrl)
                .withDefaults({
                    mode: 'cors',
                    headers: {
                        'X-Requested-With': 'Fetch'
                    }
                });
        });
        this.http = http;
    }

    login() {
        return this.auth.login(this.loginEmail, this.loginPassword)
            .then(response => {
                //console.log(response);
            })
            .catch(error => {
                //console.log(error);
            })
    }

    register() {
        return this.auth.register(this.registerEmail, this.registerUsername, this.registerPassword)
            .then(response => {
                //console.log(response);
            })
            .catch(error => {
                //console.log(error);
            })
    }
}
