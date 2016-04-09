/// <reference path="../lib/uikit/uikit.d.ts" />

export default class Notify {
    private static notificationDisplayTimeInMs = 1500
    private static notificationPosition = 'bottom-center'

    static showInfo(message: string) {
        this.showNotification(message, 'info');
    }

    static showWarning(message: string) {
        this.showNotification(message, 'warning');
    }

    static showSuccess(message: string) {
        this.showNotification(message, 'success');
    }

    static showError(message: string) {
        this.showNotification(message, 'danger');
    }

    private static showNotification(message: string, status: string) {
        UIkit.notify({
            message : message,
            status  : status,
            timeout : this.notificationDisplayTimeInMs,
            pos     : this.notificationPosition
        });
    }
}
