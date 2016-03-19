import {Aurelia, inject} from 'aurelia-framework';
import {Validation, ValidationGroup, ensure} from 'aurelia-validation';
import AuthService from 'services/auth-service';
import Notify from 'notify-client';

@inject(Aurelia, AuthService, Validation)
export class RegisterModal {
    aurelia: Aurelia;
    auth: AuthService;
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

    constructor(aurelia: Aurelia, authService: AuthService, validation: Validation) {
        this.aurelia = aurelia;
        this.auth = authService;
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
                        this.isLoading = false;
                        this.auth.login(this.email, this.password);
                    })
                    .catch(response => {
                        this.isLoading = false;
                        Notify.showError('Oops, something went wrong.');
                    });
            });
    }
}
