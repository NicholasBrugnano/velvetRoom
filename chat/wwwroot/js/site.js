// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var userName;
var roomName;

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on('ReceiveMessage', displayMessage);
connection.start();

var msgForm = document.forms.msgForm;

msgForm.addEventListener('submit', function (e) {
    e.preventDefault();
    var userMessage = document.getElementById('userMessage');
    var text = userMessage.value;
    userMessage.value = "";
    userName = document.getElementById('username').value;
    roomName = document.getElementById('roomName').value;
    sendMessage(userName, text);
});

function sendMessage(userName, message) {
    if (message && message.length) {
        if (userName == "GASTER") {
            //added an gaster egg
            connection.invoke("SendAllMessage", userName, message);
        } else {
            connection.invoke("SendMessage", roomName, userName, message);
        }
    }
}


function displayMessage(name, time, message) {
    var friendlyTime = moment(time).format('H:mm:ss');

    var userLi = document.createElement('li');
    userLi.className = 'userLi list-group-item';
    userLi.textContent = friendlyTime + ", " + name + " says:";

    var messageLi = document.createElement('li');
    messageLi.className = 'messageLi list-group-item pl-5';
    messageLi.textContent = message;

    var chatHistoryUl = document.getElementById('chatHistory');
    chatHistoryUl.appendChild(userLi);
    chatHistoryUl.appendChild(messageLi);

    $('#chatHistory').animate({ scrollTop: $('#chatHistory').prop('scrollHeight') }, 50)

}

document.getElementById("btnJoin").addEventListener('click', function (e) {
    e.preventDefault();
    var roomName = document.getElementById("roomName").value;
    if (roomName && roomName.length) {
        document.getElementById('btnJoin').disabled = true; //Could probably add a disconnect button to re-enable, but I'm lazy.
        connection.invoke("JoinRoom", roomName);
    }
})