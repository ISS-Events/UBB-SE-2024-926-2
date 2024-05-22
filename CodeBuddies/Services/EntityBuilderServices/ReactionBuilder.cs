using CodeBuddies.Models.Entities;

namespace CodeBuddies.Services.EntityBuilderServices
{
    public class ReactionBuilder : AbstractEntityBuilder<Reaction>
    {
        public override ReactionBuilder Begin()
            => (ReactionBuilder)base.Begin();

        public ReactionBuilder SetReactionValue(int value)
        {
            instance.Value = value;
            return this;
        }

        public ReactionBuilder SetReacterUserId(long userId)
        {
            instance.UserID = userId;
            return this;
        }
    }
}
