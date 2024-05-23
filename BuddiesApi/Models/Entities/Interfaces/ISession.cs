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
    }
}