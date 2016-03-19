/// <reference path="../../../lib/uikit/uikit.d.ts" />

import {inject} from 'aurelia-framework';
import {Validation, ValidationGroup, ensure} from 'aurelia-validation';
import AuthService from 'services/auth-service';
import config from 'travo-config';

@inject(AuthService, Validation)
export class LoginModal {
    auth: AuthService;
    validation: ValidationGroup;
    isLoading = false;

    @ensure(function(it){ it.isNotEmpty().isEmail() })
    email: string = "";
    @ensure(function(it){ it.isNotEmpty().hasLengthBetween(6,100) })
    password: string = "";

    constructor(authService: AuthService, validation: Validation) {
        this.auth = authService;
        this.validation = validation.on(this);
    }

    login() {
        this.isLoading = true;
        this.auth.login(this.email, this.password)
            .then(response => {
                this.isLoading = false;
                if (!response.success) {
                    UIkit.notify({
                        message : response.message,
                        status  : 'danger',
                        timeout : 2000,
                        pos     : 'top-center'
                    });
                }
            });
    }
}
