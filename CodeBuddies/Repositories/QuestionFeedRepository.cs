using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories.Interfaces;

namespace CodeBuddies.Repositories
{
    public class QuestionFeedRepository : IQuestionFeedRepository
    {
        public void AddPost(IPost post)
        {
            throw new NotImplementedException();
        }

        public void AddPostReply(IPost reply, long postId)
        {
            throw new NotImplementedException();
        }

        public void AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return new List<Category>();
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return new List<Question>();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Answer> GetAnswersOfUser(long userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Badge> GetBadgesOfUser(long userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategoriesModeratedByUser(long userId)
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryByID(long categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetCommentsOfUser(long userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Notification> GetNotificationsOfUser(long userId)
        {
            throw new NotImplementedException();
        }

        public IPost GetPost(long postId)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestion(long questionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Question> GetQuestionsOfUser(long userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reaction> GetReactionsOfPostByPostID(long postId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IPost> GetRepliesOfPost(long postId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> GetTagsOfQuestion(long questionId)
        {
            throw new NotImplementedException();
        }

        public User GetUser(long userId)
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(IPost oldPost, IPost newPost)
        {
            throw new NotImplementedException();
        }
    }
}
