using CodeBuddies.Utils;
using CodeBuddies.Utils.StreamProcessors;

namespace CodeBuddies.Models.Entities
{
    public class TextPost : IPost
    {
        #region Properties
        public long ID { get; set; }
        public long UserID { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime DateOfLastEdit { get; set; }
        public List<IReaction> Reactions { get; set; }
        #endregion
        #region Constructors
        public TextPost(long postingUserID, string content)
        {
            ID = IDGenerator.RandomLong();
            UserID = postingUserID;
            Content = content;
            DatePosted = DateTime.Now;
            DateOfLastEdit = DateTime.Now;
            Reactions = new ();
        }
        public TextPost()
        {
            ID = IDGenerator.Default();
            Content = "None";
            Reactions = new ();
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"TextPost {{postID: {ID}, userID: {UserID}, datePosted: {DatePosted}, dateOfLastEdit: {DateOfLastEdit})" +
                $"{Content}" +
                $"reactions: {CollectionStringifier<IReaction>.ApplyTo(Reactions)}}}";
        }
        #endregion
    }
}
