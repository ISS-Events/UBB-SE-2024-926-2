using CodeBuddies.Models.Entities;

namespace CodeBuddies.Services.EntityBuilderServices
{
    public class TagBuilder : AbstractEntityBuilder<Tag>
    {
        public override TagBuilder Begin()
            => (TagBuilder)base.Begin();

        public TagBuilder SetID(long id)
        {
            instance.Id = id;
            return this;
        }
        public TagBuilder SetName(string name)
        {
            instance.Name = name;
            return this;
        }
    }
}
