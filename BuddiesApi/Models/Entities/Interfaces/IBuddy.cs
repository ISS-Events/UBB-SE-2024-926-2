namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface IBuddy
    {
        #region Properties
        string BuddyName { get; set; }
        long Id { get; set; }
        List<Notification> Notifications { get; set; }
        string ProfilePhotoUrl { get; set; }
        string Status { get; set; }
        #endregion
    }
}