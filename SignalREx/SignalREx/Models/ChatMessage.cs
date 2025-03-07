namespace SignalREx.Models
{
    public class ChatMessage
    {
        public string Username { get; set; }
        public string TextMessage { get; set; }
        public DateTimeOffset DateSent { get; set; }
    }
}
