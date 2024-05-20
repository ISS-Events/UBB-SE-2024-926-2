using CodeBuddies.Utils;

namespace CodeBuddies.Models.Entities
{
    public class Tag : ITag
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Tag()
        {
            Id = IDGenerator.Default();
            Name = "None";
        }
        public override string ToString() => $"Tag {{id: {Id}, name: {Name}}}";
    }
}
