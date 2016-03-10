import {inject} from 'aurelia-framework';
import {Router, RouterConfiguration} from 'aurelia-router';

@inject(Router)
export class TravoApp {
    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
        config.title = 'Travo';

        config.map([
            { route: [''], name: 'travo-main', moduleId: 'travo-main', nav: false, title: 'Travo' }
        ]);

        this.router = router;
    }
}