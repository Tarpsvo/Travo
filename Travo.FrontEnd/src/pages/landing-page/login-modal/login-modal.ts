import {inject} from 'aurelia-framework';
import {Validation, ValidationGroup, ensure} from 'aurelia-validation';
import AuthService from 'services/auth-service';
import config from 'travo-config';

@inject(AuthService, Validation)
export class LoginModal {
    auth: AuthService;
    validation: ValidationGroup;

    @ensure(function(it){ it.isNotEmpty().isEmail() })
    email: string = "";
    @ensure(function(it){ it.isNotEmpty().hasLengthBetween(6,100) })
    password: string = "";

    constructor(authService: AuthService, validation: Validation) {
        this.auth = authService;
        this.validation = validation.on(this);
    }

    login() {
        this.auth.login(this.email, this.password)
            .then(response => response.json())
            .then(response => console.log(response))
            .catch(error => error.json())
            .then(response => console.log(response))
    }
}
