import {Aurelia, inject} from 'aurelia-framework';
import {RestClient, Router} from 'services/rest-client';

@inject(RestClient)
export default class TaskServices {
    rest: RestClient;

    constructor(restClient: RestClient) {
        this.rest = restClient;
    }

    addTask(tagId: number, taskTitle: string) {
        let task = {
            tagId: tagId,
            title: taskTitle
        };
        return this.rest.post(Router.AddTask, task);
    }

    getTask(taskId: number) {
        return this.rest.get(Router.GetTask(taskId));
    }

    patchTask(task: Object) {
        return this.rest.patch(Router.UpdateTask(task['id']), task);
    }
}
