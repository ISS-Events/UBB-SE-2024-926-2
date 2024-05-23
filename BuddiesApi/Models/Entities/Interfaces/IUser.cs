namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface IUser
    {
        #region Properties
        List<Badge> BadgeList { get; set; }
        List<Category> CategoriesModeratedList { get; set; }
        List<Notification> NotificationList { get; set; }
        long ID { get; set; }
        string Name { get; set; }
        #endregion
    }
}