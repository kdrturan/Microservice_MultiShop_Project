namespace MultiShop.Message.DAL.Entities
{
    public class UserMessage
    {
        public int UserMessageId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
        public string IsRead { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
