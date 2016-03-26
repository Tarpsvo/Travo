/// <reference path="../../../lib/autosize/jquery.autosize.d.ts" />

import {inject} from 'aurelia-framework';
import Notify from 'notify-client';
import BoardServices from 'services/board-services';
import config from 'travo-config';

@inject(BoardServices)
export class BoardView {
    boardServices: BoardServices;

    // View values
    autosizeOn = false;
    tagsWithTasks: Object[];

    constructor(boardServices: BoardServices) {
        this.boardServices = boardServices;
    }

    activate(params) {
        this.getTagsWithTasks(params.id);
    }

    userOpenedTaskForm(index: number) {
        var textArea = this.getTextAreaFromIndex(index);

        if (!this.autosizeOn) {
            this.autosizeOn = true;
            autosize(textArea);
        }

        textArea.focus();
        textArea.value = "";
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

    addNewTask(index: number) {
        var textArea = this.getTextAreaFromIndex(index);
        var taskText = textArea.value;

        if (!taskText || taskText.trim().length == 0) {
            return;
        }

        var newTask = {
            Description: taskText
        };

        var taskArray = (<Object[]> this.tagsWithTasks[index]['Tasks']);
        taskArray.push(newTask);
        this.closeTextAreaAtIndex(index);
    }

    closeTextAreaAtIndex(index: number) {
        let wrapperId = 'trv-ct-form-' + index;
        let closeAnchor = document.getElementById(wrapperId).getElementsByClassName('trv-cancel-btn')[0];
        var evt = document.createEvent("HTMLEvents");
        evt.initEvent("click", true, true);
        closeAnchor.dispatchEvent(evt);
    }

    getTextAreaFromIndex(index: number) {
        let wrapperId = 'trv-ct-form-' + index;
        let textArea = (<HTMLInputElement> document.getElementById(wrapperId).querySelector('textarea'));
        return textArea;
    }
}
