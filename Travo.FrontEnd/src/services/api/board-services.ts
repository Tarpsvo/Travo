import {Aurelia, inject} from 'aurelia-framework';
import {RestClient, Router} from 'services/rest-client';

@inject(RestClient)
export default class BoardServices {
    rest: RestClient;

    constructor(restClient: RestClient) {
        this.rest = restClient;
    }

    getTagsWithTasks(boardId: number) {
        return this.rest.get(Router.BoardTagsWithTasks(boardId));
    }

    addNewTag(boardId: number, tag: Object) {
        return this.rest.post(Router.AddNewTag(boardId), tag);
    }

    createNewBoard(teamId: number, board: Object) {
        return this.rest.post(Router.CreateNewBoard(teamId), board);
    }
}
