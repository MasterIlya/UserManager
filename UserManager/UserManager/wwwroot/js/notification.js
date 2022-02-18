function sendNotification(title, options, message) {

    if (!("Notification" in window)) {
        alert('Your browser does not support HTML Notifications, it needs to be updated.');
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
                alert('You have forbidden to show notifications');
            }
        });
    }
    else {

    }
}