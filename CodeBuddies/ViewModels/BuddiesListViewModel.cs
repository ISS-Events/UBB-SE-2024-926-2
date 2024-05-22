using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;
using CodeBuddies.Views;

namespace CodeBuddies.ViewModels
{
    public class BuddiesListViewModel : ViewModelBase
    {
        #region Fields
        private ObservableCollection<Buddy> buddies;
        private IBuddyService buddyService;
        private ISessionService sessionService;
        private Buddy? selectedBuddy;
        private string searchText;

        #endregion
        public BuddiesListViewModel(IBuddyService buddyService, ISessionService sessionService)
        {
            buddies = new ();
            this.buddyService = buddyService;
            this.sessionService = sessionService;
            selectedBuddy = null;
            searchText = string.Empty;
            GlobalEvents.BuddyPinned += HandleBuddyPinned;
            LoadBuddies();
        }
        #region Properties
        public ObservableCollection<Buddy> Buddies
        {
            get
            {
                return buddies;
            }
            set
            {
                buddies = value;
                OnPropertyChanged();
            }
        }
        public ICommand? OpenPopupCommand { get; set; }
        public IBuddyService Service
        {
            get { return buddyService; }
            set { buddyService = value; }
        }
        public Buddy? SelectedBuddy
        {
            get => selectedBuddy;
            set
            {
                selectedBuddy = value;
                OnPropertyChanged();
            }
        }
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                FilterBuddies();
                OnPropertyChanged();
            }
        }
        #endregion

        #region Lambda Commands
        public RelayCommand<Buddy> OpenModalCommand => new RelayCommand<Buddy>(_ => OpenModal());
        #endregion

        #region Methods
        private void FilterBuddies()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                LoadBuddies();
            }
            else
            {
                Buddies = new ObservableCollection<Buddy>(buddyService.FilterBuddies(SearchText));
            }
        }

        private void LoadBuddies()
        {
            List<Buddy> buddies = buddyService.GetAllBuddies();
            Buddies = new ObservableCollection<Buddy>(buddies);
        }

        private void OpenModal()
        {
            Console.WriteLine("test");
            if (SelectedBuddy != null)
            {
                var modalWindow = new BuddyModalWindow(SelectedBuddy, sessionService);
                modalWindow.Owner = Application.Current.MainWindow; // Ensure it's modal to the main window

                bool? dialogResult = modalWindow.ShowDialog();

                if (dialogResult == true)
                {
                    Debug.WriteLine("Action pressed! \n");
                }
                else
                {
                    Debug.WriteLine("Close pressed!");
                    // Handle actions if Cancelled or closed
                }
            }
        }

        public void HandleBuddyPinned()
        {
            buddies.Remove(selectedBuddy);
            buddies.Insert(0, selectedBuddy);
        }
        #endregion
    }
}