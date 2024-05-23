using CodeBuddies.Models.Entities;

namespace CodeBuddies.Repositories.Interfaces
{
    public interface IQuestionFeedRepository
    {
        void AddQuestion(Question question);
        IEnumerable<Category> GetAllCategories();
        IEnumerable<Question> GetAllQuestions();
        IEnumerable<User> GetAllUsers();
        IEnumerable<Answer> GetAnswersOfUser(long userId);
        IEnumerable<Badge> GetBadgesOfUser(long userId);
        IEnumerable<Category> GetCategoriesModeratedByUser(long userId);
        Category GetCategoryByID(long categoryId);
        IEnumerable<Comment> GetCommentsOfUser(long userId);
        IEnumerable<Notification> GetNotificationsOfUser(long userId);
        Question GetQuestion(long questionId);
        IEnumerable<Question> GetQuestionsOfUser(long userId);
        IEnumerable<Reaction> GetReactionsOfPostByPostID(long postId);
        public void AddPostReply(IPost reply, long postId);
        IEnumerable<IPost> GetRepliesOfPost(long postId);
        IEnumerable<Tag> GetTagsOfQuestion(long questionId);
        User GetUser(long userId);
        public void AddPost(IPost post);
        IPost GetPost(long postId);
        void UpdatePost(IPost oldPost, IPost newPost);
    }
}
