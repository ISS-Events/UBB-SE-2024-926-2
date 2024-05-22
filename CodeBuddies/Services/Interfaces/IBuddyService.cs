using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories;

namespace CodeBuddies.Services.Interfaces
{
    public interface IBuddyService
    {
        List<Buddy> ActiveBuddies { get; set; }
        IBuddyRepository BuddyRepository { get; set; }
        List<Buddy> InactiveBuddies { get; set; }
        Buddy ChangeBuddyStatus(Buddy buddy);
        List<Buddy> FilterBuddies(string searchText);
        List<Buddy> GetAllBuddies();
        void RefreshData();
    }
}