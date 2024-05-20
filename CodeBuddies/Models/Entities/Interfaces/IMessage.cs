namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface IMessage
    {
        #region Properties
        string Content { get; set; }
        long MessageId { get; set; }
        long SenderId { get; set; }
        DateTime TimeStamp { get; set; }
        #endregion
    }
}