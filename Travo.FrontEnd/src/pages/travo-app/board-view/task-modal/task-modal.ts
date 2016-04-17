import {inject} from 'aurelia-framework';
import {DialogController} from 'aurelia-dialog';

@inject(DialogController)
export default class TaskModal {
    dialogController: DialogController;
    task: Object;

    constructor(dialogController: DialogController) {
        dialogController.settings.lock = false;
        this.dialogController = dialogController;
    }

    activate(task) {
        this.task = task;
    }

    closeModal() {

    }
}
