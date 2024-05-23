using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Validators;
using CodeBuddies.Repositories.Interfaces;
using CodeBuddies.Resources.Data;
using CodeBuddies.Services.Interfaces;

namespace CodeBuddies.Services
{
    public class SessionService : ISessionService
    {
        #region Fields
        private ISessionRepository sessionRepository;
        #endregion

        #region Properties
        public ISessionRepository SessionRepository
        {
            get { return sessionRepository; }
            set { sessionRepository = value; }
        }
        #endregion

        public SessionService(ISessionRepository repository)
        {
            sessionRepository = repository;
        }

        #region Adders
        public long AddNewSession(string sessionName, string maxParticipants)
        {
            IValidationForNewSession validator = new ValidationForNewSession();
            validator.ValidateSessionId(sessionRepository.GetFreeSessionId());
            validator.ValidateSessionName(sessionName);
            validator.ValidateMaxNumberOfBuddies(maxParticipants);
            validator.ValidateBuddyId(Constants.CLIENT_BUDDY_ID);

            long sessionId = sessionRepository.AddNewSession(sessionName, Constants.CLIENT_BUDDY_ID, int.Parse(maxParticipants));
            return sessionId;
        }

        public void AddBuddyMemberToSession(long receiverId, long sessionId)
        {
            sessionRepository.AddBuddyMemberToSession(receiverId, sessionId);
        }
        #endregion

        #region Getters
        public string GetSessionName(long sessionId)
        {
            return sessionRepository.GetSessionName(sessionId);
        }

        public List<Session> FilterSessionsBySessionName(string sessionName)
        {
            List<Session> filteredSessions = new List<Session>();
            foreach (var session in sessionRepository.GetAllSessionsOfABuddy(Constants.CLIENT_BUDDY_ID))
            {
                if (session.Name.ToLower().Contains(sessionName.ToLower()))
                {
                    filteredSessions.Add(session);
                }
            }
            return filteredSessions;
        }

        public List<Session> GetAllSessionsForCurrentBuddy()
        {
            return sessionRepository.GetAllSessionsOfABuddy(Constants.CLIENT_BUDDY_ID);
        }
        #endregion
    }
}