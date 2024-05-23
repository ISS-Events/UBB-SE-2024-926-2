using System.Collections.ObjectModel;
using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.MVVM;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CodeBuddies.ViewModels
{
    public class ActiveInactiveBuddiesListViewModel : ViewModelBase
    {
        public ActiveInactiveBuddiesListViewModel()
        {
            buddyService = ServiceLocator.ServiceProvider.GetService<IBuddyService>()
                ?? throw new Exception("No implementation");
            active = new ObservableCollection<IBuddy>(buddyService.ActiveBuddies);
            inactive = new ObservableCollection<IBuddy>(buddyService.InactiveBuddies);
            allBuddies = new ObservableCollection<IBuddy>(buddyService.GetAllBuddies());
        }
        #region Fields
        private IBuddyService buddyService;
        private ObservableCollection<IBuddy> active;
        private ObservableCollection<IBuddy> inactive;
        private ObservableCollection<IBuddy> allBuddies;
        #endregion

        #region Properties
        public IBuddyService BuddyService
        {
            get { return buddyService; }
            set { buddyService = value; }
        }
        public ObservableCollection<IBuddy> Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<IBuddy> Inactive
        {
            get
            {
                return inactive;
            }
            set
            {
                inactive = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<IBuddy> AllBuddies
        {
            get
            {
                return allBuddies;
            }
            set
            {
                allBuddies = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public void Refresh()
        {
            BuddyService.RefreshData();
            OnPropertyChanged("ActiveBuddies");
            OnPropertyChanged("InactiveBuddies");
            OnPropertyChanged("Active");
            OnPropertyChanged("Inactive");
        }

        public void UpdateBuddyStatus(Buddy buddy)
        {
            BuddyService.ChangeBuddyStatus(buddy);
            Refresh();
        }
    }
}
