using System.Collections.ObjectModel;
using System.Windows.Input;
using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.MVVM;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
namespace CodeBuddies.ViewModels
{
    public class SessionsListViewModel : ViewModelBase
    {
        public SessionsListViewModel()
        {
            sessionService = ServiceLocator.ServiceProvider.GetService<ISessionService>()
                ?? throw new Exception("No implementation");
            GlobalEvents.BuddyAddedToSession += HandleBuddyAddedToSession;
            sessions = new ObservableCollection<ISession>(sessionService.GetAllSessionsForCurrentBuddy());
            searchBySessionName = string.Empty;
        }
        #region Fields
        private ObservableCollection<ISession> sessions;
        private readonly ISessionService sessionService;
        private string searchBySessionName;
        #endregion

        #region Commands
        public RelayCommand<ISession> LeaveSessionCommand => new (LeaveSession);
        public RelayCommand<ISession> JoinSessionCommand => new (JoinSession);
        public ICommand SendInviteNotification => new RelayCommand<Buddy>(InviteBuddyToSession);
        #endregion

        #region Properties
        public ObservableCollection<ISession> Sessions
        {
            get
            {
                return sessions;
            }
            set
            {
                sessions = value;
                OnPropertyChanged();
            }
        }

        public string SearchBySessionName
        {
            get
            {
                return searchBySessionName;
            }
            set
            {
                searchBySessionName = value;
                FilterSessionsBySessionName();
                OnPropertyChanged();
            }
        }
        #endregion
        #region Methods
        public void FilterSessionsBySessionName()
        {
            if (string.IsNullOrWhiteSpace(SearchBySessionName))
            {
                Sessions.Clear();
                Sessions = new ObservableCollection<ISession>(sessionService.GetAllSessionsForCurrentBuddy());
            }
            else
            {
                Sessions = new ObservableCollection<ISession>(sessionService.FilterSessionsBySessionName(SearchBySessionName));
            }
        }
        public void HandleBuddyAddedToSession(long buddyId, long sessionId)
        {
            Sessions = new ObservableCollection<ISession>(sessionService.GetAllSessionsForCurrentBuddy());
        }
        public void LeaveSession(ISession session)
        {
            Console.WriteLine("hi");
        }
        public void JoinSession(ISession session)
        {
            Console.WriteLine("hi");
            SessionWindow sessionWindow = new SessionWindow();
            sessionWindow.ShowDialog();
        }
        public void FilterSessionOnlyOwner(long buddyId)
        {
            Sessions = new ObservableCollection<ISession>(Sessions.Where(session => session.OwnerId == buddyId).ToList());
        }
        private void InviteBuddyToSession(Buddy buddy)
        {
        }
        #endregion
    }
}
