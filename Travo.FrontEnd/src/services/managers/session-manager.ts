import {Aurelia, inject} from 'aurelia-framework';
import AuthServices from 'services/api/auth-services';
import UserServices from 'services/api/user-services';
import config from 'travo-config';

@inject(Aurelia, AuthServices, UserServices)
export default class SessionManager {
    private aurelia: Aurelia;
    private authSvc: AuthServices;
    private userSvc: UserServices;
    private currentUser: Object = null;

    constructor(aurelia: Aurelia, authSvc: AuthServices, userSvc: UserServices) {
        this.aurelia = aurelia;
        this.authSvc = authSvc;
        this.userSvc = userSvc;

        if (SessionManager.isAuthenticated) {
            this.updateCurrentUser();
        }
    }

    // Main level methods
    login(email: string, password: string) {
        return this.authSvc.login(email, password)
            .then(accessToken => {
                this.setAccessToken(accessToken);
                return true;
            });
    }

    logOut() {
        this.deleteAccessToken();
        this.aurelia.setRoot('./dist/pages/landing-page/landing-page');
    }

    getCurrentUser() {
        return this.currentUser;
    }

    updateCurrentUser() {
        this.userSvc.getMe().then(user => this.currentUser = user);
    }

    static get accessToken() {
        return JSON.parse(localStorage[config.tokenName] || null);
    }

    static get isAuthenticated() {
        return (SessionManager.accessToken !== null);
    }

    // Helper methods
    private deleteAccessToken() {
        localStorage[config.tokenName] = null;
    }

    private setAccessToken(accessToken: string) {
        localStorage[config.tokenName] = JSON.stringify(accessToken);
    }
}
