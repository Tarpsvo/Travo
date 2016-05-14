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
}
