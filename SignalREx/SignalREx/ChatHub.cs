using Microsoft.AspNetCore.SignalR;
using SignalREx.Models;

namespace SignalREx
{
    public class ChatHub:Hub
    {
        public async Task SendAllMessages(string username, string textMessage)
        {
            var message = new ChatMessage
            {
                Username = username,
                TextMessage = textMessage,
                DateSent = DateTime.Now
            };

            await Clients.All.SendAsync("RecieveMessage",message.Username,message.TextMessage,message.DateSent);
        }
    }
}
