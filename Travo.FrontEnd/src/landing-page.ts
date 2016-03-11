import {inject} from 'aurelia-framework';
import {Router, RouterConfiguration} from 'aurelia-router';

@inject(Router)
export class LandingPage {
    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
        config.title = 'Travo';

        config.map([
            { route: [''], name: 'landing-main', moduleId: 'landing-main', nav: false, title: 'Travo' }
        ]);

        this.router = router;
    }
}
