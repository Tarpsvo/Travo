import {Aurelia, inject} from 'aurelia-framework';
import {RestClient, Router} from 'rest-client';

@inject(RestClient)
export default class TeamServices {
    rest: RestClient;

    constructor(restClient: RestClient) {
        this.rest = restClient;
    }

    getTeamsWithBoards() {
        return this.rest.get(Router.TeamsWithBoards);
    }
}
