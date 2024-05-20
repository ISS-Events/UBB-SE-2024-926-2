using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Utils;
using CodeBuddies.Utils.StreamProcessors;

namespace CodeBuddies.Models.Entities
{
    public class Answer : IAnswer
    {
        #region Properties
        public long ID { get; set; }

        public long UserID { get; set; }

        public string Content { get; set; }

        public DateTime DatePosted { get; set; }

        public DateTime DateOfLastEdit { get; set; }
        public List<IReaction> Reactions { get; set; }
        #endregion
        #region Constructor
        public Answer()
        {
            ID = IDGenerator.Default();
            Content = "None";
            Reactions = new ();
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"Answer {{id: {ID}, userID: {UserID}, datePosted: {DatePosted}, dateOfLastEdit: {DateOfLastEdit}) \n"
                + $"{Content} \n"
                + $"reactions: {CollectionStringifier<IReaction>.ApplyTo(Reactions)}}} \n";
        }
        #endregion
    }
}
