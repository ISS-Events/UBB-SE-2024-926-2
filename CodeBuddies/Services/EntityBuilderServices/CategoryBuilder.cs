using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Entities.Interfaces;

namespace CodeBuddies.Services.EntityBuilderServices
{
    public class CategoryBuilder : AbstractEntityBuilder<Category>
    {
        public override CategoryBuilder Begin()
            => (CategoryBuilder)base.Begin();

        public CategoryBuilder SetID(long categoryID)
        {
            instance.ID = categoryID;
            return this;
        }
        public CategoryBuilder SetName(string categoryName)
        {
            instance.Name = categoryName;
            return this;
        }
    }
}
