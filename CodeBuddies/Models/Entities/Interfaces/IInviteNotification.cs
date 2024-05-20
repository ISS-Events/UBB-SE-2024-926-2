namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface IInviteNotification : INotification
    {
        #region Properties
        bool IsAccepted { get; set; }
        void MarkNotification();
        #endregion
    }
}