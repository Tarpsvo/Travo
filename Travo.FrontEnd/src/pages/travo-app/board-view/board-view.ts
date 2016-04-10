/// <reference path="../../../lib/autosize/jquery.autosize.d.ts" />
/// <reference path="../../../lib/iscroll/iscroll.d.ts" />

import {inject} from 'aurelia-framework';
import Notify from 'services/notify-client';
import BoardServices from 'services/api/board-services';
import TaskServices from 'services/api/task-services';
import config from 'travo-config';

@inject(BoardServices, TaskServices)
export class BoardView {
    boardServices: BoardServices;
    taskServices: TaskServices;

    // View values
    boardId: number;
    tagsWithTasks: Object[];

    // Scrollers
    horizontalScroll: IScroll;
    verticalScrollers: Array<IScroll>;

    constructor(boardServices: BoardServices, taskServices: TaskServices) {
        this.boardServices = boardServices;
        this.taskServices = taskServices;
        this.verticalScrollers = new Array<IScroll>();
    }

    activate(params) {
        this.getTagsWithTasks(params.id);
        this.boardId = params.id;
    }

    userOpenedTaskForm(index: number) {
        var textArea = this.getTaskFormTextAreaForIndex(index);
        autosize(textArea);

        // Enable enter press on textarea
        var that = this;
        textArea.onkeyup = function(e) {
            if (e.keyCode === 13 && !e.shiftKey) {
                that.addNewTask(index);
            }
            return true;
        }

        textArea.focus();
        textArea.value = "";
    }

    getTagsWithTasks(boardId: number) {
        this.boardServices.getTagsWithTasks(boardId)
            .then(response => {
                this.tagsWithTasks = response;
                this.createScrollers();
            })
            .catch(response => {
                console.log(response);
            });
    }

    createScrollers() {
        let that = this;
        setTimeout(function() {
            that.horizontalScroll = new IScroll('#trv-tags-wrap', {
                scrollbars: true,
                scrollY: false,
                scrollX: true
            });

            let tagDivs = document.getElementsByClassName('trv-tasks-wrap');
            for(var i = 0; i < tagDivs.length; i++) {
                let scroller = new IScroll((<HTMLElement> tagDivs[i]), {
                    scrollbars: true,
                    scrollY: true,
                    scrollX: false,
                    mouseWheel: true
                });
                that.verticalScrollers.push(scroller);
            }
        }, 100);
    }

    updateScrollers() {
        let that = this;
        setTimeout(function() {
            that.horizontalScroll.refresh();
            for (var scroll of that.verticalScrollers) {
                scroll.refresh();
            }
        }, 100);
    }

    addNewTask(index: number) {
        var textArea = this.getTaskFormTextAreaForIndex(index);
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
        this.closeTaskFormTextAreaAtIndex(index);
        this.updateScrollers();

        let tagId = this.tagsWithTasks[index]['tag'].id;

        this.taskServices.addTask(tagId, taskText)
            .then(response => {
                newTask.id = response.id,
                newTask.created = response.created
            })
            .catch(error => {
                console.log("What error");
            });
    }

    closeTaskFormTextAreaAtIndex(index: number) {
        let wrapperId = 'trv-ct-form-' + index;
        let closeAnchor = document.getElementById(wrapperId).getElementsByClassName('trv-cancel-btn')[0];
        var evt = document.createEvent("HTMLEvents");
        evt.initEvent("click", true, true);
        closeAnchor.dispatchEvent(evt);
    }

    getTaskFormTextAreaForIndex(index: number) {
        let wrapperId = 'trv-ct-form-' + index;
        let textArea = (<HTMLInputElement> document.getElementById(wrapperId).querySelector('textarea'));
        return textArea;
    }

    get tagFormInput() {
        let formId = "trv-ctag-form";
        let input = (<HTMLInputElement> document.getElementById(formId).querySelector('input'));
        return input;
    }

    userOpenedTagForm() {
        var input = this.tagFormInput;

        // Enable enter press on textarea
        var that = this;
        input.onkeyup = function(e) {
            if (e.keyCode === 13 && !e.shiftKey) {
                that.addNewTag();
            }
            return true;
        }

        input.focus();
        input.value = "";
    }

    closeTagForm() {
        let wrapperId = 'trv-ctag-form';
        let closeAnchor = document.getElementById(wrapperId).getElementsByClassName('trv-cancel-btn')[0];
        var evt = document.createEvent("HTMLEvents");
        evt.initEvent("click", true, true);
        closeAnchor.dispatchEvent(evt);
    }

    addNewTag() {
        let input = this.tagFormInput;
        let tagTitle = input.value;

        if (!tagTitle || tagTitle.trim().length == 0) {
            return;
        }

        var newTag = {
            id: null,
            created: null,
            name: tagTitle,
            color: null // TODO Colors
        };

        var tagWithTasksObject = {
            tag: newTag,
            tasks: []
        };

        this.tagsWithTasks.push(tagWithTasksObject);
        this.closeTagForm();
        this.updateScrollers();

        this.boardServices.addNewTag(this.boardId, newTag)
            .then(response => {
                newTag.id = response.id,
                newTag.created = response.created
            })
            .catch(error => {
                console.log("What error");
            });
    }
}
