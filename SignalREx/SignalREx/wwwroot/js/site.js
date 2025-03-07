// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();

connection.on("RecieveMessage", displayMessage);
connection.start();

var msgForm = document.forms.msgForm;

msgForm.addEventListener('submit', function (e) {
    e.preventDefault();
    var userMessage = document.getElementById("usermessage");
    var text = userMessage.value;
    var userName = document.getElementById("username").value;

    sendMessage(userName, text)
}); //Oh lordy, it's back.

function sendMessage(userName, message) {
    if (message && message.length) {
        connection.invoke("SendAllMessages", userName, message);
    }
}

function displayMessage(name, message, time) {
    var friendlyTime = moment(time).format("HH:mm:ss");

    var userLi = document.createElement("li");
    userLi.className = "userLi list-group-item";
    userLi.textContent = friendlyTime + ", " name + ": ";

    var messageLi = document.createElement("li");
    messageLi.className = "messageLi list-group-item pl-5";
    messageLi.textContent = message;

    var chatHistoryUl = document.getElementById("chatHistory");
    chatHistoryUl.appendChild(userLi);
    chatHistory.appendChild(messageLi);

    $('#chatHistory').animate({ scrollTop: $('#chatHistory').prop('scrollHeight') }, 50);
}