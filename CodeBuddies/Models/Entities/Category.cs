using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Utils;

namespace CodeBuddies.Models.Entities
{
    public class Category : ICategory
    {
        #region Properties
        public long ID { get; set; }
        public string Name { get; set; }
        #endregion
        #region Constructor
        public Category()
        {
            ID = IDGenerator.Default();
            Name = "Unnamed category";
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"Category(categoryID: {ID}, categoryName: {Name})";
        }
        #endregion
    }
}
