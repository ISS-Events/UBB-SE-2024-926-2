using System.Drawing;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Utils;
using CodeBuddies.Utils.StreamProcessors;

namespace CodeBuddies.Models.Entities
{
    public class User : IUser
    {
            public long ID { get; set; }
            public string Name { get; set; }
            public List<INotification> NotificationList { get; set; }
            public List<ICategory> CategoriesModeratedList { get; set; }
            public List<IBadge> BadgeList { get; set; }
            public Image? ProfilePicture { get; set; }
            public User()
            {
                ID = IDGenerator.Default();
                Name = string.Empty;
                NotificationList = new ();
                CategoriesModeratedList = new ();
                BadgeList = new ();
            }
            private string ToStringNotificationList() => CollectionStringifier<INotification>.ApplyTo(NotificationList);
            private string ToStringCategoryList() => CollectionStringifier<ICategory>.ApplyTo(CategoriesModeratedList);
            private string ToStringBadgeList() => CollectionStringifier<IBadge>.ApplyTo(BadgeList);

            public override string ToString()
            {
                return $"User(id: {ID}, name: {Name}) "
                + $"notifications: {ToStringNotificationList()}"
                + $"categoriesModerated: {ToStringCategoryList()}"
                + $"badges: {ToStringBadgeList()}";
            }
        }
    }
}
}
