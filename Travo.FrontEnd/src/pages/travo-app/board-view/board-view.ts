/// <reference path="../../../lib/autosize/jquery.autosize.d.ts" />

import {inject} from 'aurelia-framework';
import Notify from 'notify-client';
import BoardServices from 'services/board-services';
import TaskServices from 'services/task-services';
import config from 'travo-config';

@inject(BoardServices, TaskServices)
export class BoardView {
    boardServices: BoardServices;
    taskServices: TaskServices;

    // View values
    autosizeOn = false;
    tagsWithTasks: Object[];

    constructor(boardServices: BoardServices, taskServices: TaskServices) {
        this.boardServices = boardServices;
        this.taskServices = taskServices;
    }

    activate(params) {
        this.getTagsWithTasks(params.id);
    }

    userOpenedTaskForm(index: number) {
        var textArea = this.getTextAreaFromIndex(index);

        if (!this.autosizeOn) {
            this.autosizeOn = true;
            autosize(textArea);

            // Enable enter press on textarea
            var that = this;
            textArea.onkeyup = function(e) {
                if (e.keyCode === 13 && !e.shiftKey) {
                    that.addNewTask(index);
                }
                return true;
            }
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
            id: null,
            created: null,
            description: taskText
        };

        var taskArray = (<Object[]> this.tagsWithTasks[index]['tasks']);
        taskArray.push(newTask);
        this.closeTextAreaAtIndex(index);

        let tagId = this.tagsWithTasks[index]['tag'].id;

        // Now post it and then edit newTask
        this.taskServices.addTask(tagId, taskText)
            .then(response => {
                newTask.id = response.id,
                newTask.created = response.created
            })
            .catch(error => {
                console.log("What error");
            });
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
