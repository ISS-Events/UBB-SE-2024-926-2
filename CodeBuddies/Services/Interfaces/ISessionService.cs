using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories.Interfaces;

namespace CodeBuddies.Services.Interfaces
{
    public interface ISessionService
    {
        ISessionRepository SessionRepository { get; set; }
        void AddBuddyMemberToSession(long receiverId, long sessionId);
        long AddNewSession(string sessionName, string maxParticipants);
        List<Session> FilterSessionsBySessionName(string sessionName);
        List<Session> GetAllSessionsForCurrentBuddy();
        string GetSessionName(long sessionId);
    }
}