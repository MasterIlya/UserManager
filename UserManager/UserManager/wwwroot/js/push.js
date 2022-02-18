
const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/notification")
    .withAutomaticReconnect(() => { PushInf(userId) })
    .configureLogging(signalR.LogLevel.Information)
    .build();

function PushInf(userId) {
    $.ajax({
        dataType: "json",
        url: "/Hub/RegistrateHubConnectionId",
        method: "POST",
        data: {
            "connectionId": hubConnection.connectionId,
            "userId": userId
        }
    });
}

hubConnection.on("Notify", function (message) {

    sendNotification("New message", {
        body: "Click on the notification to go to the latest messages!",
        icon: "https://miro.medium.com/max/1032/1*oY4cw-0zKtS4fwatBBHeTg@2x.jpeg",
        dir: "auto"
    }, message);

});

hubConnection.start()
