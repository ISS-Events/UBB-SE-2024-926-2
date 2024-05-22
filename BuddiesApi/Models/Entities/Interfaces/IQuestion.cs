using CodeBuddies.Models.Entities.Interfaces;

namespace CodeBuddies.Models.Entities
{
    public interface IQuestion : IPost
    {
        #region Properties
        Category? Category { get; set; }
        List<Tag> Tags { get; set; }
        string? Title { get; set; }
        #endregion
    }
}