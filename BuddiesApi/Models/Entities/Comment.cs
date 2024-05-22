
using CodeBuddies.Utils;
using CodeBuddies.Utils.StreamProcessors;

namespace CodeBuddies.Models.Entities
{
    public class Comment : Interfaces.IComment
    {
        #region Properties
        public long ID { get; set; }

        public long UserID { get; set; }

        public string Content { get; set; }

        public DateTime DatePosted { get; set; }

        public DateTime DateOfLastEdit { get; set; }
        public List<Reaction> Reactions { get; set; }
        #endregion
        #region Constructor
        public Comment()
        {
            ID = IDGenerator.Default();
            UserID = IDGenerator.Default();
            Content = string.Empty;
            DatePosted = DateTime.Now;
            DateOfLastEdit = DateTime.Now;
            Reactions = new ();
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"Comment {{postID: {ID}, userID: {UserID}, datePosted: {DatePosted}, dateOfLastEdit: {DateOfLastEdit})"
                + $"{Content}"
                + $"reactions: {CollectionStringifier<Reaction>.ApplyTo(Reactions)}}}";
        }
        #endregion
    }
}
