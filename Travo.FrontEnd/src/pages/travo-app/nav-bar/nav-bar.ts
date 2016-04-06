import {inject, bindable} from 'aurelia-framework';
import SessionManager from 'services/managers/session-manager';

@inject(SessionManager)
export class NavBar {
    @bindable router = null;
    sessionMgr: SessionManager;

    constructor(sessionMgr: SessionManager) {
        this.sessionMgr = sessionMgr;
    }

    get currentUserName() {
        if (this.sessionMgr.getCurrentUser() != null && this.sessionMgr.getCurrentUser()['displayName'] != null) {
            return this.sessionMgr.getCurrentUser()['displayName'];
        } else {
            return null;
        }
    }

    logOut() {
        this.sessionMgr.logOut()
    }
}
