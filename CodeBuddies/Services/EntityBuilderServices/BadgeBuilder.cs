using CodeBuddies.Models.Entities;

namespace CodeBuddies.Services.EntityBuilderServices
{
    public class BadgeBuilder : AbstractEntityBuilder<Badge>
    {
        public override BadgeBuilder Begin()
        {
            return (BadgeBuilder)base.Begin();
        }
        public BadgeBuilder SetName(string name)
        {
            instance.Name = name;
            return this;
        }
        public BadgeBuilder SetDescription(string description)
        {
            instance.Description = description;
            return this;
        }
        internal BadgeBuilder SetID(long id)
        {
            instance.ID = id;
            return this;
        }
    }
}
