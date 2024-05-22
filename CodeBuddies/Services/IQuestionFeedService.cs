using CodeBuddies.Models.Entities;

namespace CodeBuddies.Services
{
    public interface IQuestionFeedService
    {
        void AddQuestion(string title, string content, Category category);
        int FilterQuestionsAnsweredLastYear();
        int FilterQuestionsAnsweredThisMonth();
        int CountQuestionsInLast7Days();
        List<Question> FindQuestionsByPartialStringInAnyField(string textToBeSearchedBy);
        List<Category> GetAllCategories();
        List<Question> GetAllQuestions();
        List<Answer> GetAnswersOfUser(long userId);
        List<Badge> GetBadgesOfUser(long userId);
        List<Comment> GetCommentsOfUser(long userId);
        List<Question> GetCurrentQuestions();
        Question GetQuestion(long questionId);
        List<Question> GetQuestionsOfCategory(Category? category);
        List<Question> GetQuestionsOfUser(long userId);
        List<Question> GetQuestionsSortedByScoreAscending();
        List<Question> GetQuestionsSortedByScoreDescending();
        List<Question> GetQuestionsWithAtLeastOneAnswer();
        List<IPost> GetRepliesOfPost(long postId);
        List<Tag> GetTagsOfQuestion(long questionId);
        User GetUser(long userId);
        List<Question> SortQuestionsByDateAscending();
        List<Question> SortQuestionsByDateDescending();
        List<Question> SortQuestionsByNumberOfAnswersAscending();
        List<Question> SortQuestionsByNumberOfAnswersDescending();
        void UpdatePost(IPost oldPost, IPost newPost);
    }
}

