using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Utils;
using CodeBuddies.Utils.StreamProcessors;

namespace CodeBuddies.Models.Entities
{
    public class User : IUser
    {
        #region Properties
        public long ID { get; set; }
            public string Name { get; set; }
            public List<Notification> NotificationList { get; set; }
            public List<Category> CategoriesModeratedList { get; set; }
            public List<Badge> BadgeList { get; set; }
        #endregion
        #region Constructor
        public User()
            {
                ID = IDGenerator.Default();
                Name = string.Empty;
                NotificationList = new ();
                CategoriesModeratedList = new ();
                BadgeList = new ();
            }
        #endregion
        #region Methods
        private string ToStringNotificationList()
            => CollectionStringifier<Notification>.ApplyTo(NotificationList);
        private string ToStringCategoryList()
            => CollectionStringifier<Category>.ApplyTo(CategoriesModeratedList);
        private string ToStringBadgeList()
            => CollectionStringifier<Badge>.ApplyTo(BadgeList);
        public override string ToString()
            => $"User(id: {ID}, name: {Name}) "
            + $"notifications: {ToStringNotificationList()}"
            + $"categoriesModerated: {ToStringCategoryList()}"
            + $"badges: {ToStringBadgeList()}";
        #endregion
    }
}