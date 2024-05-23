using CodeBuddies.Utils;

namespace CodeBuddies.Models.Entities
{
    public class Reaction : IReaction
    {
        #region Properties
        public long Id { get; set; }
        public int Value { get; set; }
        public long UserID { get; set; }
        #endregion
        #region Constructors
        public Reaction()
        {
            Id = IDGenerator.Default();
            Value = 0;
            UserID = IDGenerator.Default();
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"Value: {Value}, ID: {UserID})";
        }
        #endregion
    }
}
