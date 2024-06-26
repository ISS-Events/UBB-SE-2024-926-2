﻿namespace CodeBuddies.Models.Entities
{
    public class InfoNotification : Notification
    {
        #region Constructors
        public InfoNotification(long notificationId, DateTime timeStamp, string type, string status, string description, long senderId, long receiverId, long sessionId)
                         : base(notificationId, timeStamp, type, status, description, senderId, receiverId, sessionId)
        {
        }
        public InfoNotification() : base()
        {
        }
        #endregion
    }
}
