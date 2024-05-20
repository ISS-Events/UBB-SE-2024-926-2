using System.Drawing;

namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface IBadge
    {
        #region Properties
        string Description { get; set; }
        long ID { get; set; }
        string Name { get; set; }
        Image? Image { get; set; }
        #endregion
    }
}