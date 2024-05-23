using CodeBuddies.Models.Entities;

namespace CodeBuddies.Services.EntityBuilderServices
{
    public class AnswerBuilder : AbstractEntityBuilder<Answer>
    {
        public override AnswerBuilder Begin()
        {
            return (AnswerBuilder)base.Begin();
        }
        public AnswerBuilder SetId(long id)
        {
            instance.ID = id;
            return this;
        }
        public AnswerBuilder SetUserId(long userId)
        {
            instance.UserID = userId;
            return this;
        }
        public AnswerBuilder SetContent(string content)
        {
            instance.Content = content;
            return this;
        }
        public AnswerBuilder SetDatePosted(DateTime datePosted)
        {
            instance.DatePosted = datePosted;
            return this;
        }
        public AnswerBuilder SetDateOfLastEdit(DateTime dateOfLastEdit)
        {
            instance.DateOfLastEdit = dateOfLastEdit;
            return this;
        }
        public AnswerBuilder SetReactions(List<Reaction> reactions)
        {
            instance.Reactions = reactions;
            return this;
        }
    }
}
