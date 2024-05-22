using CodeBuddies.Models.Entities;
namespace CodeBuddies.Services.EntityBuilderServices
{
    public class UserBuilder : AbstractEntityBuilder<User>
    {
        public override UserBuilder Begin()
            => (UserBuilder)base.Begin();
        public UserBuilder SetName(string name)
        {
            instance.Name = name;
            return this;
        }
        public UserBuilder SetNotificationList(List<Notification> notifications)
        {
            instance.NotificationList = notifications;
            return this;
        }
        public UserBuilder SetCategoriesModeratedList(List<Category> categories)
        {
            instance.CategoriesModeratedList = categories;
            return this;
        }
        public UserBuilder SetBadgeList(List<Badge> badges)
        {
            instance.BadgeList = badges;
            return this;
        }
    }
}
