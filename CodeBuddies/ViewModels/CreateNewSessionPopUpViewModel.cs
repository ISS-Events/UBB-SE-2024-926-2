using CodeBuddies.Models.Entities;
using CodeBuddies.MVVM;
using CodeBuddies.Repositories;
using CodeBuddies.Repositories.Interfaces;
using CodeBuddies.Resources.Data;
using CodeBuddies.Services;
using CodeBuddies.Services.Interfaces;

namespace CodeBuddies.ViewModels
{
    public class CreateNewSessionPopUpViewModel : ViewModelBase
    {
        private readonly ISessionService sessionService;

        public CreateNewSessionPopUpViewModel(ISessionService sessionService)
        {
            this.sessionService = sessionService;
        }

        public void AddNewSession(string sessionName, string maxParticipants)
        {
            long sessionId = sessionService.AddNewSession(sessionName, maxParticipants);
            GlobalEvents.RaiseBuddyAddedToSessionEvent(Constants.CLIENT_BUDDY_ID, sessionId);
        }
    }
}
