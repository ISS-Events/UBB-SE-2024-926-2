using static CodeBuddies.Resources.Data.Constants;

namespace CodeBuddies.Models.Validators
{
    public class ValidationForNewSession : IValidationForNewSession
    {
        public void ValidateSessionName(string sessionName)
        {
            if (sessionName.Length < 3 || sessionName.Length > 50)
            {
                throw new ArgumentException("Session name must be between 3 and 50 characters long.");
            }
        }

        public void ValidateMaxNumberOfBuddies(string maxNumberOfBuddiesText)
        {
            if (!int.TryParse(maxNumberOfBuddiesText, out int maxNumberOfBuddies))
            {
                throw new ArgumentException("Maximum number of buddies must be a valid integer.");
            }
            else if (maxNumberOfBuddies < 0 || maxNumberOfBuddies > MAX_NUMBER_OF_BUDDIES_PER_SESSION)
            {
                throw new ArgumentOutOfRangeException("Maximum number of buddies must be between 0 and " + MAX_NUMBER_OF_BUDDIES_PER_SESSION + ".");
            }
        }

        public void ValidateBuddyId(long buddyId) =>
            ArgumentOutOfRangeException.ThrowIfNegative(buddyId);

        public void ValidateSessionId(long sessionId) =>
            ArgumentOutOfRangeException.ThrowIfNegative(sessionId);
    }
}