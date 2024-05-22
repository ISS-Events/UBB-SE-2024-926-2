using CodeBuddies.Models.Entities;

namespace CodeBuddies.Repositories
{
    public interface IBuddyRepository
    {
        List<Buddy> GetActiveBuddies();
        List<Buddy> GetAllBuddies();
        List<Buddy> GetInactiveBuddies();
        Buddy UpdateBuddyStatus(Buddy buddy);
        void AddBuddy(long buddyId, string buddyName, string buddyProfile, string status);
        void ClearDatabase();
    }
}