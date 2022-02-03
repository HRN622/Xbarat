var connection = new signalR.HubConnectionBuilder()
    .withUrl("/notificationhub")
    .build();
connection.start();

function Init() {
    var NewPeopleForm = $("#Create");
    NewPeopleForm.on("submit", function (e) {
        connection.invoke('SendNotification', "Happy Birth Day!!!!!!!");
    })
}

connection.on('getNotification', getMessage);

function getMessage(sender, message) {
    $("#notification").append("<h1 style='color: red'>" + message + "</h1>");
};

$(document).ready(function () {
    Init();
});