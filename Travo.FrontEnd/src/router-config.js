import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';

@inject(Router)
export default class {
    constructor(router) {
        this.router = router;
    }

    configure() {
        var appRouterConfig = function(config) {
            config.title = 'Travo';

            config.map([
                { route: ['', 'landing-page'], name: 'landing-page', moduleId: './landing-page/landing-page', nav: false, title: 'Travo' }
            ]);
        }

        this.router.configure(appRouterConfig);
    }
}