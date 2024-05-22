using CodeBuddies.Models.Entities;

namespace CodeBuddies.Repositories
{
    public interface INotificationRepository
    {
        List<Notification> GetAll();
        List<Notification> GetAllByBuddyId(long buddyId);
        long GetFreeNotificationId();
        void RemoveById(long notificationId);
        void Save(Notification notification);
        void ClearDatabase();
    }
}