using CodeBuddies.Utils;

namespace CodeBuddies.Models.Entities
{
    public class Tag : ITag
    {
        #region Properties
        public long Id { get; set; }
        public string Name { get; set; }
        #endregion
        #region Constructor
        public Tag()
        {
            Id = IDGenerator.Default();
            Name = "None";
        }
        #endregion
        #region Methods
        public override string ToString() => $"Tag {{id: {Id}, name: {Name}}}";
        #endregion
    }
}
