using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using Week08_1_SignalREx.Models;

namespace Week08_1_SignalREx
{
    public class ChatHub : Hub
    {
        private readonly ConcurrentDictionary<string, ChatRoom> chatRooms = new ConcurrentDictionary<string, ChatRoom>();
        private readonly ConcurrentDictionary<string, string> userNames = new ConcurrentDictionary<string, string>();
        private readonly AppDbContext appDbContext;

        public ChatHub(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task SendAllMessage(string userName, string textMessage)
        {
            var message = new ChatMessage
            {
                UserName = userName,
                Message = textMessage,
                TimeStamp = DateTimeOffset.Now
            };

            await Clients.All.SendAsync("ReceiveMessage", message.UserName, message.TimeStamp, message.Message);

        }

        public async Task JoinRoom(string roomName)
        {
            roomName = roomName.ToLower();

            string currentConnectionId = Context.ConnectionId;

            if (!chatRooms.ContainsKey(roomName))
            {
                //Creates a new room if one doesn't already exist.
                ChatRoom newRoom = new ChatRoom()
                {
                    RoomName = roomName,
                    ConnectionIds = new List<string>()
                };

                //Joins said room.
                newRoom.ConnectionIds.Add(currentConnectionId);
                chatRooms.TryAdd(roomName, newRoom);
            }
            else
            {
                //Gets a room. Takes two steps because the Internet is the work of Satan.
                ChatRoom existingRoom = new ChatRoom();
                chatRooms.TryGetValue(roomName, out existingRoom);

                //Joins the room.
                existingRoom.ConnectionIds.Add(currentConnectionId);

                //Updates the dictionary object because now there's a new ConnectionId
                chatRooms.TryAdd(roomName, existingRoom);
            }
            await Groups.AddToGroupAsync(currentConnectionId, roomName);
            await Clients.Caller.SendAsync("ReceiveMessage", "Chat Hub", DateTimeOffset.Now, $"Joined room: {roomName}");
        }

        public async Task SendMessage(string roomName, string userName, string textMessage)
        {
            if (!userNames.ContainsKey(Context.ConnectionId))
            {
                userNames.TryAdd(Context.ConnectionId,userName);
            }

            var message = new ChatMessage
            {
                UserName = userName,
                Message = textMessage,
                TimeStamp = DateTimeOffset.Now
            };

            await Clients.Group(roomName.ToLower()).SendAsync("ReceiveMessage", message.UserName, message.TimeStamp, message.Message);


        }
    }
}