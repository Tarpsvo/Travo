import {inject} from 'aurelia-framework';
import {Router, RouterConfiguration} from 'aurelia-router';

@inject(Router)
export class TravoApp {
    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
        config.title = 'Travo';

        config.map([
            { route: [''], name: 'tasks-page', moduleId: './tasks-page/tasks-page', nav: false, title: 'Travo - Tasks' }
        ]);

        this.router = router;
    }
}
