/// <reference path="./lib/jquery/jquery.d.ts" />

import {inject} from 'aurelia-framework';
import {HttpClient, json} from 'aurelia-fetch-client';
import config from 'travo-config';

@inject(HttpClient)
export class RestClient {
    http: HttpClient;

    constructor(httpClient: HttpClient) {
        httpClient.configure(httpconfig => {
            httpconfig
                .withBaseUrl(config.baseUrl)
                .withDefaults({
                    mode: 'cors',
                    headers: {
                        'X-Requested-With': 'Fetch'
                    }
                });
        });
        this.http = httpClient;
    }

    get(endpoint: Endpoint) {
        return this.request(endpoint.method, endpoint.path);
    }

    post(endpoint: Endpoint, body: Object) {
        return this.request(endpoint.method, endpoint.path, body);
    }

    request(method: string, path: string, body?: Object) {
        let requestOptions = {
            method: method,
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: {}
        }

        if (typeof body === 'object') {
            requestOptions.body = json(body);
        }

        return this.http.fetch(path, requestOptions).then(response => {
            if (response.status >= 200 && response.status < 400) {
                return response.json().catch(error => null);
            }

            // Log the error to console
            if (response.status == 400) response.json().then(e => console.log("Server responded with status code 400.", e));
            else console.log("Server responded with status code: " + response.status);

            throw response;
        });
    }

    // Custom handler for x-www-form-url-encoded
    postForm(endpoint: Endpoint, body: Object) {
        let requestOptions = {
            method: endpoint.method,
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: {}
        }

        if (typeof body === 'object') {
            requestOptions.body = jQuery.param(body);
        }

        return this.http.fetch(endpoint.path, requestOptions).then(response => {
            if (response.status >= 200 && response.status < 400) {
                return response.json().catch(error => null);
            }

            // Log the error to console
            if (response.status == 400) response.json().then(e => console.log("Server responded with status code 400.", e));
            else console.log("Server responded with status code: " + response.status);

            throw response;
        });
    }
}

class Endpoint {
    method: string;
    path: string;

    constructor(method: string, path: string) {
        this.method = method;
        this.path = path;
    }
}

export class Router {
    public static Register = new Endpoint('POST', 'account/register');
    public static RequestToken = new Endpoint('POST', 'account/token');
}
