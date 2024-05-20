using CodeBuddies.Utils;

namespace CodeBuddies.Models.Entities
{
    public class Reaction : IReaction
    {
        public int Value { get; set; }
        public long UserID { get; set; }
        public Reaction()
        {
            Value = 0;
            UserID = IDGenerator.Default();
        }

        public override string ToString()
        {
            return $"Value: {Value}, ID: {UserID})";
        }
    }
}
