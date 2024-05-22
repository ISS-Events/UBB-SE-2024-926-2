using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;

namespace CodeBuddies.Services.Interfaces
{
    public interface INotificationService
    {
        INotificationRepository NotificationRepository { get; set; }

        void AddNotification(Notification notification);
        List<Notification> GetAllNotificationsForCurrentBuddy();
        long GetFreeNotificationId();
        void RemoveNotification(Notification notification);
    }
}