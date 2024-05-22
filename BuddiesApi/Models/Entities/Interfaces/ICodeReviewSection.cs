namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface ICodeReviewSection
    {
        #region Properties
        string CodeSection { get; set; }
        long Id { get; set; }
        bool IsClosed { get; set; }
        List<Message> Messages { get; set; }
        long OwnerId { get; set; }
        #endregion
    }
}