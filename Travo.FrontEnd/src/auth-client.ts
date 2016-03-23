import config from 'travo-config';

export default class AuthClient {
    private accessToken: string = null;

    constructor() {
        this.accessToken = JSON.parse(localStorage[config.tokenName] || null);
    }

    setAccessToken(accessToken: string) {
        localStorage[config.tokenName] = JSON.stringify(accessToken);
        this.accessToken = accessToken;
    }

    getAccessToken() {
        return this.accessToken;
    }

    deleteAccessToken() {
        localStorage[config.tokenName] = null;
        this.accessToken = null;
    }

    isAuthenticated() {
        return (this.accessToken !== null);
    }
}
