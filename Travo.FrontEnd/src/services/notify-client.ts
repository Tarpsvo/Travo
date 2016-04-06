/// <reference path="../lib/uikit/uikit.d.ts" />

export default class Notify {
    private static notificationDisplayTimeInMs = 1500
    private static notificationPosition = 'bottom-center'

    static showInfo(message: string) {
        UIkit.notify({
            message : message,
            status  : 'info',
            timeout : this.notificationDisplayTimeInMs,
            pos     : this.notificationPosition
        });
    }

    static showSuccess(message: string) {
        UIkit.notify({
            message : message,
            status  : 'success',
            timeout : this.notificationDisplayTimeInMs,
            pos     : this.notificationPosition
        });
    }

    static showError(message: string) {
        UIkit.notify({
            message : message,
            status  : 'danger',
            timeout : this.notificationDisplayTimeInMs,
            pos     : this.notificationPosition
        });
    }
}
