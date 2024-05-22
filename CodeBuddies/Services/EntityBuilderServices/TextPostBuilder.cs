using CodeBuddies.Models.Entities;

namespace CodeBuddies.Services.EntityBuilderServices
{
    public class TextPostBuilder : AbstractEntityBuilder<TextPost>
    {
        public override TextPostBuilder Begin()
            => (TextPostBuilder)base.Begin();
        public TextPostBuilder SetID(long id)
        {
            instance.ID = id;
            return this;
        }
        public TextPostBuilder SetUserId(long userId)
        {
            instance.UserID = userId;
            return this;
        }
        public TextPostBuilder SetContent(string content)
        {
            instance.Content = content;
            return this;
        }
        public TextPostBuilder SetDatePosted(DateTime datePosted)
        {
            instance.DatePosted = datePosted;
            return this;
        }
        public TextPostBuilder SetDateOfLastEdit(DateTime dateOfLastEdit)
        {
            instance.DateOfLastEdit = dateOfLastEdit;
            return this;
        }
        public TextPostBuilder SetReactions(List<Reaction> reactions)
        {
            instance.Reactions = reactions;
            return this;
        }
    }
}
