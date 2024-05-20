namespace CodeBuddies.Models.Entities
{
    public static class GlobalEvents
    {
        #region Properties
        public static event BuddyPinnedHandler BuddyPinned;
        public delegate void BuddyPinnedHandler();
        public delegate void BuddyAddedToSessionEventHandler(long buddyId, long sessionId);
        public static event BuddyAddedToSessionEventHandler BuddyAddedToSession;
        #endregion
        #region Methods

        /// <summary>
        /// Raise the BuddyAddedToSession event
        /// </summary>
        /// <param name="buddyId"></param>
        /// <param name="sessionId"></param>
        public static void RaiseBuddyAddedToSessionEvent(long buddyId, long sessionId)
        {
            BuddyAddedToSession?.Invoke(buddyId, sessionId);
        }

        /// <summary>
        /// Raise the BuddyPinned event
        /// </summary>
        public static void RaiseBuddyPinned()
        {
            BuddyPinned?.Invoke();
        }
        #endregion
    }
}
