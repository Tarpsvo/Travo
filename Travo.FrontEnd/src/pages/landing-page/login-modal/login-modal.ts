/// <reference path="../../../lib/uikit/uikit.d.ts" />

import {inject} from 'aurelia-framework';
import {Validation, ValidationGroup, ensure} from 'aurelia-validation';
import AuthService from 'services/auth-service';
import Notify from 'notify-client';
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
            .then(response => this.isLoading = false)
            .catch(response => {
                this.isLoading = false;
                if (response.status == 400) Notify.showError("Wrong username or password.");
                else Notify.showError("Connection error, please try again.");
            });
    }
}
