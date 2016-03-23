/// <reference path="../../../lib/uikit/uikit.d.ts" />

import {Aurelia, inject} from 'aurelia-framework';
import {Validation, ValidationGroup, ensure} from 'aurelia-validation';
import AuthServices from 'services/auth-services';
import Notify from 'notify-client';

@inject(Aurelia, AuthServices, Validation)
export class RegisterModal {
    app: Aurelia;
    auth: AuthServices;
    validation: ValidationGroup;
    isLoading = false;

    // User inputs (bound in viewmodel)
    @ensure(function(it){ it.isNotEmpty().isEmail() })
    email: string = "";
    @ensure(function(it){ it.isNotEmpty().hasLengthBetween(3,30) })
    displayName: string = "";
    @ensure(function(it){ it.isNotEmpty().hasLengthBetween(6,100) })
    password: string = "";
    confirmPassword: string = "";

    constructor(aurelia: Aurelia, authServices: AuthServices, validation: Validation) {
        this.app = aurelia;
        this.auth = authServices;
        this.validation = validation.on(this)
            .ensure('confirmPassword', (config) => {config.computedFrom(['password'])})
                .isNotEmpty()
                .hasLengthBetween(6,100)
                .isEqualTo( () => { return this.password; }, 'the entered password');
    }

    register() {
        this.validation.validate()
            .then( () => {
                this.isLoading = true;
                this.auth.register(this.email, this.displayName, this.password)
                    .then(response => {
                        this.auth.login(this.email, this.password).then(response => {
                            // Hide UIkit modal to remove classes set by it
                            // Then redirect to to travo-app
                            UIkit.modal('.uk-modal').hide();
                            let appl = this.app;
                            jQuery('.uk-modal').on({
                                'hide.uk.modal': function() {
                                    appl.setRoot('./dist/pages/travo-app/travo-app');
                                }
                            });
                        });
                    })
                    .catch(response => {
                        this.isLoading = false;
                        Notify.showError('Oops, something went wrong.');
                    });
            });
    }
}
