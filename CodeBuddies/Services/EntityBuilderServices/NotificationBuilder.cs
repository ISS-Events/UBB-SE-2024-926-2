using CodeBuddies.Models.Entities;
using CodeBuddies.Models.Entities.Interfaces;

namespace CodeBuddies.Services.EntityBuilderServices
{
    public class QuestionBuilder : AbstractEntityBuilder<Question>
    {
        public override QuestionBuilder Begin()
            => (QuestionBuilder)base.Begin();
        public QuestionBuilder SetId(long id)
        {
            instance.ID = id;
            return this;
        }
        public QuestionBuilder SetTitle(string title)
        {
            instance.Title = title;
            return this;
        }
        public QuestionBuilder SetCategory(Category category)
        {
            instance.Category = category;
            return this;
        }
        public QuestionBuilder SetTags(List<Tag> tags)
        {
            instance.Tags = tags;
            return this;
        }
        public QuestionBuilder SetUserId(long userId)
        {
            instance.UserID = userId;
            return this;
        }
        public QuestionBuilder SetContent(string content)
        {
            instance.Content = content;
            return this;
        }
        public QuestionBuilder SetPostTime(DateTime postTime)
        {
            instance.DatePosted = postTime;
            return this;
        }
        public QuestionBuilder SetEditTime(DateTime editTime)
        {
            instance.DateOfLastEdit = editTime;
            return this;
        }
        public QuestionBuilder SetReactions(List<Reaction> reactions)
        {
            instance.Reactions = reactions;
            return this;
        }
    }
}
