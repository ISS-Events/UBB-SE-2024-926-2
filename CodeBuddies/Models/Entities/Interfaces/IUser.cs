using System.Drawing;

namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface IUser
    {
        #region Properties
        List<IBadge> BadgeList { get; set; }
        List<ICategory> CategoriesModeratedList { get; set; }
        List<INotification> NotificationList { get; set; }
        Image? ProfilePicture { get; set; }
        long ID { get; set; }
        string Name { get; set; }
        #endregion
    }
}