import {inject} from 'aurelia-framework';
import Notify from 'notify-client';
import BoardServices from 'services/board-services';
import config from 'travo-config';

@inject(BoardServices)
export class BoardView {
    boardServices: BoardServices;

    // View values
    tagsWithTasks: Object[];

    constructor(boardServices: BoardServices) {
        this.boardServices = boardServices;
    }

    activate(params) {
        this.getTagsWithTasks(params.id);
    }

    getTagsWithTasks(boardId: number) {
        console.log("Getting tags with tasks.");
        this.boardServices.getTagsWithTasks(boardId)
            .then(response => {
                this.tagsWithTasks = response;
                console.log(this.tagsWithTasks);
            })
            .catch(response => {
                console.log(response);
            });
    }
}
