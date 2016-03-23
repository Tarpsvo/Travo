import {inject} from 'aurelia-framework';
import AuthServices from 'services/auth-services';

@inject(AuthServices)
export class NavBar {
    auth: AuthServices;

    constructor(authServices: AuthServices) {
        this.auth = authServices;
    }

    logOut() {
        this.auth.logOut()
    }
}
