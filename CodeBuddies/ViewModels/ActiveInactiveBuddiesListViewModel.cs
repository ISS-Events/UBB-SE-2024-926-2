using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Repositories.Interfaces;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using CodeBuddies.Views.UserControls;

namespace CodeBuddies.ViewModels
{
    public class ActiveInactiveBuddiesListViewModel : ViewModelBase
    {
        public ActiveInactiveBuddiesListViewModel(IBuddyService buddyService)
        {
            this.buddyService = buddyService;
            active = new ObservableCollection<IBuddy>();
            inactive = new ObservableCollection<IBuddy>();
            allBuddies = new ObservableCollection<IBuddy>();
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
