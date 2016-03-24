import {Aurelia, inject} from 'aurelia-framework';
import {RestClient, Router} from 'rest-client';

@inject(RestClient)
export default class BoardServices {
    rest: RestClient;

    constructor(restClient: RestClient) {
        this.rest = restClient;
    }

    getTagsWithTasks(boardId: number) {
        return this.rest.get(Router.BoardTagsWithTasks(boardId));
    }
}
 {}
