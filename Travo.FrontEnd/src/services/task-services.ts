import {Aurelia, inject} from 'aurelia-framework';
import {RestClient, Router} from 'rest-client';

@inject(RestClient)
export default class TaskServices {
    rest: RestClient;

    constructor(restClient: RestClient) {
        this.rest = restClient;
    }

    addTask(tagId: number, taskDescription: string) {
        let task = {
            tagId: tagId,
            description: taskDescription
        };
        return this.rest.post(Router.AddTask, task);
    }
}
