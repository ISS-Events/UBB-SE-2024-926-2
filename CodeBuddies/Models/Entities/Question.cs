using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Utils.StreamProcessors;

namespace CodeBuddies.Models.Entities
{
    public class Question : IQuestion
    {
        #region Properties
        public string? Title { get; set; }
        public Category? Category { get; set; }
        private readonly IPost post;
        public List<Tag> Tags { get; set; }
        public long ID
        {
            get => post.ID; set { post.ID = value; }
        }
        public long UserID
        {
            get => post.UserID; set { post.UserID = value; }
        }

        public string Content
        {
            get => post.Content; set { post.Content = value; }
        }
        public DateTime DatePosted
        {
            get => post.DatePosted; set { post.DatePosted = value; }
        }
        public DateTime DateOfLastEdit
        {
            get => post.DateOfLastEdit; set { post.DateOfLastEdit = value; }
        }
        public List<Reaction> Reactions
        {
            get => post.Reactions; set { post.Reactions = value; }
        }
        #endregion
        #region Constructor
        public Question()
        {
            post = new TextPost();
            Tags = new ();
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"Question(postID: {ID}, userID: {UserID}, title:{Title} , category: {Category})"
                + $"{Content}"
                + $"reactions: {CollectionStringifier<Reaction>.ApplyTo(Reactions)}"
                + $"tags: {CollectionStringifier<Tag>.ApplyTo(Tags)}";
        }
        #endregion
    }
}