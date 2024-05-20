namespace CodeBuddies.Models.Entities
{
    public interface IReaction
    {
        #region Properties
        long UserID { get; set; }
        int Value { get; set; }
        #endregion
    }
}
