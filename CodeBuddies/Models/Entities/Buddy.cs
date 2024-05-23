using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Utils;

namespace CodeBuddies.Models.Entities
{
    public class Buddy : IBuddy
    {
        #region Properties
        public long Id { get; set; }
        public string BuddyName { get; set; }
        public string ProfilePhotoUrl { get; set; }
        public string Status { get; set; }
        public List<Notification> Notifications { get; set; }
        #endregion
        #region Constructors
        public Buddy()
        {
            Id = IDGenerator.Default();
            BuddyName = string.Empty;
            ProfilePhotoUrl = string.Empty;
            Status = string.Empty;
            Notifications = new List<Notification>();
        }
        public Buddy(long buddyId, string buddyName, string profilePhotoUrl, string status, List<Notification> notifications)
        {
            Id = buddyId;
            BuddyName = buddyName;
            ProfilePhotoUrl = profilePhotoUrl;
            Status = status;
            Notifications = notifications;
        }
        #endregion
    }
}