using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Utils;

namespace CodeBuddies.Models.Entities
{
    public class Category : ICategory
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public Category()
        {
            ID = IDGenerator.Default();
            Name = "Unnamed category";
        }

        public override string ToString()
        {
            return $"Category(categoryID: {ID}, categoryName: {Name})";
        }
    }
}
