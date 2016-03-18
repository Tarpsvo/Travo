import {Aurelia, inject} from 'aurelia-framework';
import {Validation, ValidationGroup, ensure} from 'aurelia-validation';
import AuthService from 'services/auth-service';

@inject(Aurelia, AuthService, Validation)
export class RegisterModal {
    aurelia: Aurelia;
    auth: AuthService;
    validation: ValidationGroup;

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
        this.validation.validate() //the validate will fulfil when validation is valid, and reject if not
            .then( () => {
                this.auth.register(this.email, this.displayName, this.password)
                    .then(response => {
                        this.auth.login(this.email, this.password)
                            .then(response => response.json())
                            .then(response => {
                                console.log(response);
                                this.aurelia.setRoot('./dist/pages/travo-app/travo-app');
                            })
                            .catch(response => {
                                if (response.status == 400) {
                                    response.json().then(error => {
                                        console.log(error);
                                    });
                                }
                            });
                    })
                    .catch(response => {
                        if (response.status == 400) {
                            response.json().then(error => {
                                console.log(error);
                            });
                        }
                    });
            });
    }
}
