/// <reference path="../../../lib/uikit/uikit.d.ts" />

import {Aurelia, inject} from 'aurelia-framework';
import {Validation, ValidationGroup, ensure} from 'aurelia-validation';
import AuthServices from 'services/auth-services';
import Notify from 'notify-client';
import config from 'travo-config';

@inject(Aurelia, AuthServices, Validation)
export class LoginModal {
    app: Aurelia;
    auth: AuthServices;
    validation: ValidationGroup;
    isLoading = false;

    @ensure(function(it){ it.isNotEmpty().isEmail() })
    email: string = "";
    @ensure(function(it){ it.isNotEmpty().hasLengthBetween(6,100) })
    password: string = "";

    constructor(aurelia: Aurelia, authServices: AuthServices, validation: Validation) {
        this.app = aurelia;
        this.auth = authServices;
        this.validation = validation.on(this);
    }

    login() {
        this.isLoading = true;
        this.auth.login(this.email, this.password)
            .then(response => {
                // Hide UIkit modal to remove classes set by it
                // Then redirect to to travo-app
                UIkit.modal('.uk-modal').hide();
                let appl = this.app;
                jQuery('.uk-modal').on({
                    'hide.uk.modal': function(){
                        appl.setRoot('./dist/pages/travo-app/travo-app');
                    }
                });
            })
            .catch(response => {
                this.isLoading = false;
                if (response.status == 400) Notify.showError("Wrong username or password.");
                else Notify.showError("Connection error, please try again.");
            });
    }
}
