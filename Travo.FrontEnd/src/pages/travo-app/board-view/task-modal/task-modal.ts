import {inject} from 'aurelia-framework';
import {DialogController} from 'aurelia-dialog';
import TaskServices from '../../../../services/api/task-services';

@inject(DialogController, TaskServices)
export default class TaskModal {
    dialogController: DialogController;
    taskServices: TaskServices;
    task: Object;

    constructor(dialogController: DialogController, taskServices: TaskServices) {
        dialogController.settings.lock = false;
        this.dialogController = dialogController;
        this.taskServices = taskServices;
    }

    activate(task) {
        this.task = task;
        this.taskServices.getTask(task.id)
            .then(task => {
                this.task = task;
            })
            .catch(response => {
                console.log(response);
            });
    }

    get descriptionTextArea() {
        let formId = 'trv-dsc-form';
        let input = (<HTMLInputElement> document.getElementById(formId).querySelector('textarea'));
        return input;
    }

    userOpenedDescriptionForm() {
        var textarea = this.descriptionTextArea;

        // Enable enter press on textarea
        var that = this;
        textarea.onkeyup = function(e) {
            if (e.keyCode === 13 && !e.shiftKey) {
                that.updateTask();
            }
            return true;
        }

        textarea.focus();
        textarea.value = "";
    }

    closeDescriptionForm() {
        let wrapperId = 'trv-dsc-form';
        let closeAnchor = document.getElementById(wrapperId).getElementsByClassName('trv-cancel-btn')[0];
        var evt = document.createEvent("HTMLEvents");
        evt.initEvent('click', true, true);
        closeAnchor.dispatchEvent(evt);
    }

    updateTask() {
        var newDescription = this.descriptionTextArea.value;
        this.task['description'] = newDescription;

        this.taskServices.patchTask(this.task)
            .then(update => {
                console.log(update);
                this.closeDescriptionForm();
            })
            .catch(response => {
                console.log(response);
                this.closeDescriptionForm();
            });
    }
}
