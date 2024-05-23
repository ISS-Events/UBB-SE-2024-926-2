
using CodeBuddies.Utils;

namespace CodeBuddies.Models.Entities
{
    public class Badge : Interfaces.IBadge
    {
        #region Properties
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        #endregion
        #region Constructor
        public Badge()
        {
            ID = IDGenerator.Default();
            Name = "New Badge";
            Description = "None provided";
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"Badge(id: {ID}, badgeName: {Name})"
                + $"badgeDescription: {Description}";
        }
        #endregion
    }
}

