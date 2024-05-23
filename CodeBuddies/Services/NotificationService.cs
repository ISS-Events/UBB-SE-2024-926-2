using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;
using CodeBuddies.Resources.Data;
using CodeBuddies.Services.Interfaces;

namespace CodeBuddies.Services
{
    public class NotificationService : INotificationService
    {
        #region Constructor
        public NotificationService(INotificationRepository repository)
        {
            notificationRepository = repository;
        }
        #endregion
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
        #region Methods
        public List<Notification> GetAllNotificationsForCurrentBuddy()
        {
            return notificationRepository.GetAllByBuddyId(Constants.CLIENT_BUDDY_ID);
        }
        public long GetFreeNotificationId()
        {
            return notificationRepository.GetFreeNotificationId();
        }
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
