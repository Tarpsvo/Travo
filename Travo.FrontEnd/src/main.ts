import SessionManager from './services/managers/session-manager';
import StatusServices from './services/api/status-services';

export function configure(aurelia) {
    aurelia.use
        .standardConfiguration()
        .developmentLogging()
        .plugin('aurelia-validation')
        .plugin('aurelia-dialog');

    aurelia
        .start()
        .then(() => {
            let statusServices = aurelia.container.get(StatusServices);
            statusServices.getStatus()
                .then(response => {
                    let root = SessionManager.isAuthenticated ? './dist/pages/travo-app/travo-app' : './dist/pages/landing-page/landing-page';
                    aurelia.setRoot(root);
                })
                .catch(response => {
                    aurelia.setRoot('./dist/pages/travo-offline/travo-offline');
                });
        });
}
