using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;
using CodeBuddies.Resources.Data;
using CodeBuddies.Services.Interfaces;

namespace CodeBuddies.Services
{
    public class NotificationService : INotificationService
    {
        #region Fields
        private INotificationRepository notificationRepository;
        #endregion

        #region Properties
        public INotificationRepository NotificationRepository
        {
            get { return notificationRepository; }
            set { notificationRepository = value; }
        }
        #endregion

        public NotificationService(INotificationRepository repo)
        {
            notificationRepository = repo;
        }

        #region Getters
        public List<Notification> GetAllNotificationsForCurrentBuddy()
        {
            return notificationRepository.GetAllByBuddyId(Constants.CLIENT_BUDDY_ID);
        }

        public long GetFreeNotificationId()
        {
            return notificationRepository.GetFreeNotificationId();
        }
        #endregion

        #region Methods
        public void RemoveNotification(Notification notification)
        {
            notificationRepository.RemoveById(notification.Id);
        }

        public void AddNotification(Notification notification)
        {
            notificationRepository.Save(notification);
        }
        #endregion
    }
}
