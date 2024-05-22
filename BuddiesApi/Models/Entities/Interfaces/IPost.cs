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
        List<Reaction> Reactions { get; set; }
        #endregion
        #region Methods
        int Score() => CollectionSummerFactory<Reaction>.GetFromMapping((Reaction reaction) => reaction.Value).ApplyTo(Reactions);
        void AddReaction(Reaction reaction) => Reactions.Add(reaction);
        #endregion
    }
}
