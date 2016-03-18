import AuthService from 'services/auth-service';

export function configure(aurelia) {
    aurelia.use
        .standardConfiguration()
        .developmentLogging()
        .plugin('aurelia-validation');

    aurelia
        .start()
        .then(() => {
            var auth = aurelia.container.get(AuthService);
            let root = auth.isAuthenticated() ? './dist/pages/travo-app/travo-app' : './dist/pages/landing-page/landing-page';
            aurelia.setRoot(root);
        });
}
