import {inject} from 'aurelia-framework';
import StatusServices from '../../services/api/status-services';
import NotifyClient from '../../services/notify-client';

@inject(StatusServices)
export class TravoOffline {
    statusServices: StatusServices;

    constructor(statusServices: StatusServices) {
        this.statusServices = statusServices;
    }

    updateStatus() {
        let statusField = document.getElementById('trv-server-status');
        let button = document.getElementById('trv-update-status-btn');

        button.classList.add('trv-updating');
        this.statusServices.getStatus()
            .then(response => {
                NotifyClient.showSuccess('The server is online.');
                button.classList.remove('trv-updating');
                if (statusField.classList.contains('trv-offline')) {
                    statusField.classList.remove('trv-offline');
                    statusField.classList.add('trv-online');
                    statusField.innerHTML = "online";
                }
            })
            .catch(response => {
                NotifyClient.showWarning('The server is offline.');
                button.classList.remove('trv-updating');
                if (statusField.classList.contains('trv-online')) {
                    statusField.classList.remove('trv-online');
                    statusField.classList.add('trv-offline');
                    statusField.innerHTML = "offline";
                }
            });
    }
}
