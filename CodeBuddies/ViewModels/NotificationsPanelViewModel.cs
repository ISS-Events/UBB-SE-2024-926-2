using System.Collections.ObjectModel;
using System.Windows;
using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Models.Exceptions;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Repositories.Interfaces;
using CodeBuddies.Resources.Data;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CodeBuddies.ViewModels
{
    public class NotificationsPanelViewModel : ViewModelBase
    {
        public NotificationsPanelViewModel()
        {
            notificationService = ServiceLocator.ServiceProvider.GetService<INotificationService>()
                ?? throw new Exception("No implementation");
            sessionService = ServiceLocator.ServiceProvider.GetService<ISessionService>()
                ?? throw new Exception("No implementation");
            notifications = new ObservableCollection<Notification>(notificationService.GetAllNotificationsForCurrentBuddy());
        }

        #region Fields
        private ObservableCollection<Notification> notifications;
        private readonly INotificationService notificationService;
        private readonly ISessionService sessionService;
        #endregion

        #region Commands
        public RelayCommand<Notification> AcceptCommand => new (AcceptInvite);
        public RelayCommand<Notification> DeclineCommand => new (DeclineInvite);
        public RelayCommand<Notification> MarkReadCommand => new (MarkReadNotification);
        #endregion

        #region Properties
        public ObservableCollection<Notification> Notifications
        {
            get
            {
                return notifications;
            }
            set
            {
                notifications = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Methods
        private void AcceptInvite(Notification notification)
        {
            SendAcceptedInfoNotification(notification);
            // save the new member
            try
            {
                sessionService.AddBuddyMemberToSession(notification.ReceiverId, notification.SessionId);
                // Raise the event to notify the other components they need to update their sessions list
                GlobalEvents.RaiseBuddyAddedToSessionEvent(notification.ReceiverId, notification.SessionId);
            }
            catch (EntityAlreadyExists)
            {
                ShowErrorPopup("You are already a member of the session " + sessionService.GetSessionName(notification.SessionId));
            }
            finally
            {
                RemoveNotification(notification);
            }
        }
        private void DeclineInvite(Notification notification)
        {
            // send an information notification informing the inviter that the user declined
            SendDeclinedInfoNotification(notification);
            RemoveNotification(notification);
        }
        private void MarkReadNotification(Notification notification)
        {
            RemoveNotification(notification);
        }
        private void SendDeclinedInfoNotification(Notification notification)
        {
            // Reverse sender and receiver ids because this notification goes backwards
            Notification declinedNotification = new InfoNotification(notificationService.GetFreeNotificationId(), DateTime.Now, "rejectInformation", "pending", Constants.CLIENT_NAME + " rejected your invitation", notification.ReceiverId, notification.SenderId, notification.SessionId);
            notificationService.AddNotification(declinedNotification);
        }
        private void SendAcceptedInfoNotification(Notification notification)
        {
            // Reverse sender and receiver ids because this notification goes backwards
            Notification acceptedNotification = new InfoNotification(notificationService.GetFreeNotificationId(), DateTime.Now, "successInformation", "pending", Constants.CLIENT_NAME + " accepted your invitation!", notification.ReceiverId, notification.SenderId, notification.SessionId);
            notificationService.AddNotification(acceptedNotification);
        }
        private void ShowErrorPopup(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void RemoveNotification(Notification notification)
        {
            // update optimistically
            notifications.Remove(notification);
            // remove from db
            try
            {
                notificationService.RemoveNotification(notification);
            }
            catch (Exception)
            {
                // if failure, fetch again
                Notifications = new ObservableCollection<Notification>(notificationService.GetAllNotificationsForCurrentBuddy());
            }
        }
        #endregion
    }
}