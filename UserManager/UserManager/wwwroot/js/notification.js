function sendNotification(title, options, message) {

    if (!("Notification" in window)) {
        alert('Ваш браузер не поддерживает HTML Notifications, его необходимо обновить.');
    }
    else if (Notification.permission === "granted") {

        var notification = new Notification(title, options);

        notification.onclick = function () {

            let contoller = "/messages"
            let action = "/getinbox"
            let userId = "?recipientId=" + message
            document.location.href = contoller + action + userId
        };
    }
    else if (Notification.permission !== 'denied') {
        Notification.requestPermission(function (permission) {

            if (permission === "granted") {
                var notification = new Notification(title, options);

            } else {
                alert('Вы запретили показывать уведомления');
            }
        });
    }
    else {

    }
}