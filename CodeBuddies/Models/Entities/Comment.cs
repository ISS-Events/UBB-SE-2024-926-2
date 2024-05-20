using CodeBuddies.Utils;
using CodeBuddies.Utils.StreamProcessors;

namespace CodeBuddies.Models.Entities
{
    public class Comment : IComment
    {
        public long ID { get; set; }

        public long UserID { get; set; }

        public string Content { get; set; }

        public DateTime DatePosted { get; set; }

        public DateTime DateOfLastEdit { get; set; }
        public List<IReaction> Reactions { get; set; }
        public Comment()
        {
            ID = IDGenerator.Default();
            UserID = IDGenerator.Default();
            Content = string.Empty;
            DatePosted = DateTime.Now;
            DateOfLastEdit = DateTime.Now;
            Reactions = new ();
        }
        public override string ToString()
        {
            return $"Comment {{postID: {ID}, userID: {UserID}, datePosted: {DatePosted}, dateOfLastEdit: {DateOfLastEdit})"
                + $"{Content}"
                + $"reactions: {CollectionStringifier<IReaction>.ApplyTo(Reactions)}}}";
        }
    }
}
