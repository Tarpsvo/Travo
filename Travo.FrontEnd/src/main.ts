import AuthService from 'services/auth-service';

export function configure(aurelia) {
    aurelia.use
        .standardConfiguration()
        .developmentLogging();


    aurelia
        .start()
        .then(() => {
            var auth = aurelia.container.get(AuthService);
            let root = auth.isAuthenticated() ? 'pages/travo-app/travo-app' : 'pages/landing-page/landing-page';
            aurelia.setRoot(root);
        });
}
