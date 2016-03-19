import {inject} from 'aurelia-framework';
import AuthService from 'services/auth-service';

@inject(AuthService)
export class NavBar {
    auth: AuthService;

    constructor(authService: AuthService) {
        this.auth = authService;
    }

    logOut() {
        this.auth.logOut()
    }
}
