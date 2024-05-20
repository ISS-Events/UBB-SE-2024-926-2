namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface IBuddy
    {
        #region Properties
        string BuddyName { get; set; }
        long Id { get; set; }
        List<INotification> Notifications { get; set; }
        string ProfilePhotoUrl { get; set; }
        string Status { get; set; }
        #endregion
        #region Methods
        void AcceptInvite();
        void CreateNewSession(string sessionName);
        void DeclineInvite();
        void SendInvite();
        #endregion
    }
}