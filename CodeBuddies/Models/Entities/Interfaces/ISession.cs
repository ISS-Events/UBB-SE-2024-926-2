namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface ISession
    {
        #region Properties
        List<long> Buddies { get; set; }
        List<CodeContribution> CodeContributions { get; set; }
        List<CodeReviewSection> CodeReviewSections { get; set; }
        DateTime CreationDate { get; set; }
        DrawingBoard DrawingBoard { get; set; }
        List<string> FilePaths { get; set; }
        long Id { get; set; }
        DateTime LastEditDate { get; set; }
        List<Message> Messages { get; set; }
        string Name { get; set; }
        long OwnerId { get; set; }
        TextEditor TextEditor { get; set; }
        #endregion
        #region Methods
        void AddBuddy(long buddyId);
        void AddCodeContribution(int buddyId, DateTime date, int contributionValue);
        void LeaveSession(long buddyId);
        void PostCodeReviewSection(ICodeReviewSection codeReviewSection);
        void PostCodeReviewSectionMessage(long codeReviewSectionId, IMessage message);
        void PostMessage(IMessage message);
        void RemoveBuddy(long buddyId);
        void UploadFile(string filePath);
        #endregion
    }
}