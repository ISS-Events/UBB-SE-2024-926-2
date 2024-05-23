using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;
using CodeBuddies.Services.Interfaces;

namespace CodeBuddies.Services
{
    public class BuddyService : IBuddyService
    {
        #region Constructor
        public BuddyService(IBuddyRepository repo)
        {
            budyRepository = repo;
            activeBuddies = new ();
            inactiveBuddies = new ();
        }
        #endregion
        #region Fields
        private IBuddyRepository budyRepository;
        private List<Buddy> activeBuddies;
        private List<Buddy> inactiveBuddies;
        #endregion

        #region Properties
        public IBuddyRepository BuddyRepository
        {
            get { return budyRepository; }
            set { budyRepository = value; }
        }
        public List<Buddy> ActiveBuddies
        {
            get { return activeBuddies; }
            set { activeBuddies = value; }
        }
        public List<Buddy> InactiveBuddies
        {
            get { return inactiveBuddies; }
            set { inactiveBuddies = value; }
        }
        #endregion
        #region Methods
        public List<Buddy> GetAllBuddies()
        {
            return BuddyRepository.GetAllBuddies();
        }

        public List<Buddy> FilterBuddies(string searchText)
        {
            List<Buddy> filteredBuddies = new ();
            foreach (Buddy buddy in BuddyRepository.GetAllBuddies())
            {
                if (buddy.BuddyName.ToLower().Contains(searchText.ToLower()))
                {
                    filteredBuddies.Add(buddy);
                }
            }
            return filteredBuddies;
        }
        public void RefreshData()
        {
            ActiveBuddies = BuddyRepository.GetActiveBuddies();
            InactiveBuddies = BuddyRepository.GetInactiveBuddies();
        }

        public Buddy ChangeBuddyStatus(Buddy buddy)
        {
            Buddy changedBuddy = BuddyRepository.UpdateBuddyStatus(buddy);
            return changedBuddy;
        }
        #endregion
    }
}