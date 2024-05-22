namespace CodeBuddies.Models.Entities
{
    public interface IReaction
    {
        #region Properties
        long Id { get; set; }
        long UserID { get; set; }
        int Value { get; set; }
        #endregion
    }
}
