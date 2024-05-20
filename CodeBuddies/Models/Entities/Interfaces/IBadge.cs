using System.Drawing;

namespace CodeBuddies.Models.Entity
{
    public interface IBadge
    {
        string Description { get; set; }
        long ID { get; set; }
        string Name { get; set; }
        Image? Image { get; set; }
    }
}