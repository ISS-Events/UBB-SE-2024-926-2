namespace CodeBuddies.Models.Entities
{
    public class InviteNotification : Notification
    {
        #region Properties
        public bool IsAccepted { get; set; }
        #endregion
        #region Constructors
        public InviteNotification(long notificationId, DateTime timeStamp, string type, string status, string description, long senderId, long receiverId, long sessionId, bool isAccepted)
            : base(notificationId, timeStamp, type, status, description, senderId, receiverId, sessionId)
        {
            IsAccepted = isAccepted;
        }

        public InviteNotification() : base()
        {
            IsAccepted = false;
        }
        #endregion
    }
}
