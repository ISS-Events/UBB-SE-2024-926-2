using CodeBuddies.Utils;
using CodeBuddies.Utils.StreamProcessors;

namespace CodeBuddies.Models.Entities
{
    public class Answer : IAnswer
    {
        public long ID { get; set; }

        public long UserID { get; set; }

        public string Content { get; set; }

        public DateTime DatePosted { get; set; }

        public DateTime DateOfLastEdit { get; set; }
        public List<IReaction> Reactions { get; set; }

        public Answer()
        {
            ID = IDGenerator.Default();
            Content = "None";
#pragma warning disable IDE0028 // Simplify collection initialization
            Reactions = new ();
#pragma warning restore IDE0028 // Simplify collection initialization
        }

        public override string ToString()
        {
            return $"Answer {{id: {ID}, userID: {UserID}, datePosted: {DatePosted}, dateOfLastEdit: {DateOfLastEdit}) \n"
                + $"{Content} \n"
                + $"reactions: {CollectionStringifier<IReaction>.ApplyTo(Reactions)}}} \n";
        }
    }
}
