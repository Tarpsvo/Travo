import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import config from 'travo-config';

@inject(HttpClient)
export class LandingPage {
    http: HttpClient;

    constructor(http: HttpClient) {
        http.configure(httpconfig => {
            httpconfig
                .rejectErrorResponses()
                .withBaseUrl(config.baseUrl)
                .withDefaults({
                    mode: 'cors',
                    headers: {
                        'X-Requested-With': 'Fetch'
                    }
                });
        });
        this.http = http;
    }
}
