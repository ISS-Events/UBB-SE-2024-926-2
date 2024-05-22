using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Utils;

namespace CodeBuddies.Models.Entities
{
    public abstract class Notification : INotification
    {
        #region Properties
        public long NotificationId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public long SenderId { get; set; }
        public long ReceiverId { get; set; }
        public long SessionId { get; set; }
        #endregion
        #region Constructors
        public Notification(long notificationId, DateTime timeStamp, string type, string status, string description, long senderId, long receiverId, long sessionId)
        {
            NotificationId = notificationId;
            TimeStamp = timeStamp;
            Type = type;
            Status = status;
            Description = description;
            SenderId = senderId;
            ReceiverId = receiverId;
            SessionId = sessionId;
        }

        public Notification()
        {
            NotificationId = IDGenerator.Default();
            TimeStamp = DateTime.Now;
            Type = string.Empty;
            Status = string.Empty;
            Description = string.Empty;
            SenderId = IDGenerator.Default();
            ReceiverId = IDGenerator.Default();
            SessionId = IDGenerator.Default();
        }
        #endregion
    }
}