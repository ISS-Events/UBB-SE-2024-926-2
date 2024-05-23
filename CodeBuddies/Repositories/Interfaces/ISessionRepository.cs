using CodeBuddies.Models.Entities;

namespace CodeBuddies.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        void AddBuddyMemberToSession(long buddyId, long sessionId);
        long AddNewSession(string sessionName, long ownerId, int maxParticipants);
        List<Session> GetAllSessionsOfABuddy(long buddyId);
        List<long> GetBuddiesForSpecificSession(long sessionId);
        List<CodeContribution> GetCodeContributionsForSpecificSession(long sessionId);
        List<CodeReviewSection> GetCodeReviewSectionsForSpecificSession(long sessionId);
        long GetFreeSessionId();
        List<Message> GetMessagesForSpecificCodeReview(long codeReviewId);
        List<Message> GetMessagesForSpecificSession(long sessionId);
        string GetSessionName(long sessionId);
    }
}