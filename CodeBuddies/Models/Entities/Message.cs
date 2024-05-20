using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Utils;

namespace CodeBuddies.Models.Entities
{
    public class Message : IMessage
    {
        #region Prperties
        public long MessageId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Content { get; set; }
        public long SenderId { get; set; }
        #endregion
        #region Constructors
        public Message(long messageId, DateTime timeStamp, string messageContent, long senderId)
        {
            MessageId = messageId;
            TimeStamp = timeStamp;
            Content = messageContent;
            SenderId = senderId;
        }
        public Message()
        {
            MessageId = IDGenerator.Default();
            TimeStamp = DateTime.Now;
            Content = string.Empty;
            SenderId = IDGenerator.Default();
        }
        #endregion
    }
}