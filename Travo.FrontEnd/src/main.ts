import SessionManager from 'services/managers/session-manager';

export function configure(aurelia) {
    aurelia.use
        .standardConfiguration()
        .developmentLogging()
        .plugin('aurelia-validation');

    aurelia
        .start()
        .then(() => {
            let root = SessionManager.isAuthenticated ? './dist/pages/travo-app/travo-app' : './dist/pages/landing-page/landing-page';
            aurelia.setRoot(root);
        });
}
