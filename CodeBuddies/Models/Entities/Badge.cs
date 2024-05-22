using System.Drawing;
using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Utils;

namespace CodeBuddies.Models.Entities
{
    public class Badge : IBadge
    {
        #region Properties
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // public Image? Image { get; set; }
        #endregion
        #region Constructor
        public Badge()
        {
            ID = IDGenerator.Default();
            Name = "New Badge";
            Description = "None provided";
            // Image = null;
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

