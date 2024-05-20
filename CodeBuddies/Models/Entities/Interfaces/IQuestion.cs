using CodeBuddies.Models.Entities.Interfaces;

namespace CodeBuddies.Models.Entities
{
    public interface IQuestion : IPost
    {
        #region Properties
        ICategory? Category { get; set; }
        List<ITag> Tags { get; set; }
        string? Title { get; set; }
        #endregion
    }
}