import {Aurelia, inject} from 'aurelia-framework';
import {RestClient, Router} from 'services/rest-client';

@inject(RestClient)
export default class UserServices {
    rest: RestClient;

    constructor(restClient: RestClient) {
        this.rest = restClient;
    }

    getMe() {
        return this.rest.get(Router.Me);
    }
}
