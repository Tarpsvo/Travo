import AuthClient from 'auth-client';

export function configure(aurelia) {
    aurelia.use
        .standardConfiguration()
        .developmentLogging()
        .plugin('aurelia-validation');

    aurelia
        .start()
        .then(() => {
            var authClient = aurelia.container.get(AuthClient);
            let root = authClient.isAuthenticated() ? './dist/pages/travo-app/travo-app' : './dist/pages/landing-page/landing-page';
            aurelia.setRoot(root);
        });
}
