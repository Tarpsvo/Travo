import AuthService from 'auth-service';

export function configure(aurelia) {
    aurelia.use
        .standardConfiguration()
        .developmentLogging();


    aurelia
        .start()
        .then(() => {
            var auth = aurelia.container.get(AuthService);
            let root = auth.isAuthenticated() ? 'travo-app' : 'landing-page';
            aurelia.setRoot(root);
        });
}