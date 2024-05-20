using CodeBuddies.Utils.StreamProcessors;

namespace CodeBuddies.Models.Entities
{
    public interface IPost
    {
        #region Properties
        long ID { get; set; }
        long UserID { get; set; }
        string Content { get; set; }
        DateTime DatePosted { get; set; }
        DateTime DateOfLastEdit { get; set; }
        List<IReaction> Reactions { get; set; }
        #endregion
        #region Methods
        int Score() => CollectionSummerFactory<IReaction>.GetFromMapping(MapReactionToInt).ApplyTo(Reactions);
        void AddReaction(IReaction reaction) => Reactions.Add(reaction);
        #endregion
    }
}
