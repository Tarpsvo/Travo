import {inject} from 'aurelia-framework';
import {Router, RouterConfiguration} from 'aurelia-router';

@inject(Router)
export class TravoApp {
    router: Router;

    configureRouter(config: RouterConfiguration, router: Router) {
        config.title = 'Travo';

        config.map([
            { route: ['', 'boards'], name: 'boards-view', moduleId: './boards-view/boards-view', nav: false, title: 'Boards' },
            { route: ['settings'], name: 'settings-view', moduleId: './settings-view/settings-view', nav: false, title: 'Settings' },
            { route: ['timetracking'], name: 'timetracking-view', moduleId: './timetracking-view/timetracking-view', nav: false, title: 'Timetracking' },
            { route: ['board/:id'], name: 'board-view', moduleId: './board-view/board-view', nav: false, title: 'Board' }
        ]);

        this.router = router;
    }
}
