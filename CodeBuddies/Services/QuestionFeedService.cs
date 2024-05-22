using CodeBuddies.Models.Entities;
using CodeBuddies.Repositories.Interfaces;
using CodeBuddies.Services.EntityBuilderServices;
using CodeBuddies.Services.Interfaces;
using CodeBuddies.Utils;
using CodeBuddies.Utils.Functionals;
using CodeBuddies.Utils.StreamProcessors;

namespace CodeBuddies.Services
{
    internal class QuestionFeedService : IQuestionFeedService
    {
        private readonly IQuestionFeedRepository repository;

        private readonly List<Question> currentQuestions;
        public QuestionFeedService(IQuestionFeedRepository repository)
        {
            this.repository = repository;
            currentQuestions = GetAllQuestions();
        }

        public User GetUser(long userId)
        {
            return repository.GetUser(userId);
        }

        public void AddPost(IPost post)
        {
            repository.AddPost(post);
        }

        public IPost GetPost(long postId)
        {
            return repository.GetPost(postId);
        }

        public void UpdatePost(IPost oldPost, IPost newPost)
        {
            repository.UpdatePost(oldPost, newPost);
        }

        public Question GetQuestion(long userId)
        {
            return repository.GetQuestion(userId);
        }

        public List<Question> GetAllQuestions()
        {
            return repository.GetAllQuestions().ToList();
        }

        public void AddPostReply(IPost reply, long postId)
        {
            repository.AddPostReply(reply, postId);
        }

        public List<IPost> GetRepliesOfPost(long postId)
        {
            return repository.GetRepliesOfPost(postId).ToList();
        }

        public List<Question> GetQuestionsOfCategory(Category? category)
        {
            if (category == null)
            {
                return new ();
            }
            bool QuestionIsOfCategory(Question question) => question.Category?.Name == category.Name;
            return StreamProcessor<Question, Question>.FilterCollection(repository.GetAllQuestions(), QuestionIsOfCategory).ToList();
        }

        public List<Question> GetQuestionsWithAtLeastOneAnswer()
        {
            bool QuestionHasAtLeastOneAnswer(Question question) => repository.GetRepliesOfPost(question.ID).Any(Filters.IPostIsAnswer);
            List<Question> filteredQuestions = repository.GetAllQuestions().Where(QuestionHasAtLeastOneAnswer).ToList();
            return filteredQuestions;
        }

        public List<Question> FindQuestionsByPartialStringInAnyField(string textToBeSearchedBy)
        {
            bool PartialStringMatches(string str) => str.Contains(textToBeSearchedBy, StringComparison.CurrentCultureIgnoreCase);
            bool TagNameMatches(Tag tag) => PartialStringMatches(tag.Name);
            bool AnyTagPartialMatches(Question question) => question.Tags.Where(TagNameMatches).Any();
            bool AnyKeywordInTitleMatches(Question question) => question.Title?.Split(" ").Where(PartialStringMatches).Any() ?? false;
            bool MasterFilterCondition(Question question) => AnyTagPartialMatches(question) || AnyKeywordInTitleMatches(question);

            return StreamProcessor<Question, Question>.FilterCollection(repository.GetAllQuestions(), MasterFilterCondition).ToList();
        }

        public List<Question> GetQuestionsSortedByScoreAscending()
        {
            Dictionary<Question, int> questionToReactionValueMapping = new ();

            List<Question> listOfQuestions = currentQuestions;
            CollectionSummer<Reaction> reactionValueSummer = new ((Reaction reaction) => reaction.Value);
            void AddMappingForQuestion(Question question) =>
                questionToReactionValueMapping[question] = GetReactionScore(repository.GetReactionsOfPostByPostID(question.ID).ToList());

            listOfQuestions.ForEach(AddMappingForQuestion);

            Dictionary<Question, int> sortedQuestionToReactionValueMap =
                questionToReactionValueMapping.OrderBy(questionValuePair => questionValuePair.Value).ToDictionary();

            return sortedQuestionToReactionValueMap.Keys.ToList();
        }

        public List<Question> GetQuestionsSortedByScoreDescending()
        {
            List<Question> questions = GetQuestionsSortedByScoreAscending();
            questions.Reverse();
            return questions;
        }

        private static int GetReactionScore(List<Reaction> voteList)
        {
            static int GetReactionValue(Reaction reaction) => reaction.Value;
            CollectionReducer<Reaction, int> summer = new (
                mapper: GetReactionValue,
                folder: Aggregator.Addition,
                defaultResult: 0);
            return summer.MapThenFold(voteList);
        }

        public List<Question> SortQuestionsByNumberOfAnswersAscending()
        {
            Dictionary<Question, int> questionToIAnswerCountMapping = new ();
            void ProcessQuestion(Question question)
                => questionToIAnswerCountMapping[question]
                = StreamProcessor<IPost, IPost>.FilterCollection(repository.GetRepliesOfPost(question.ID), Filters.IPostIsAnswer).Count();
            currentQuestions.ForEach(ProcessQuestion);
            Dictionary<Question, int> sortedMapping = questionToIAnswerCountMapping.OrderBy(x => x.Value).ToDictionary();
            return sortedMapping.Keys.ToList();
        }

        public List<Question> SortQuestionsByNumberOfAnswersDescending()
        {
            List<Question> questions = SortQuestionsByNumberOfAnswersAscending();
            questions.Reverse();
            return questions;
        }

        public List<Question> SortQuestionsByDateAscending()
        {
            Dictionary<Question, DateTime> iQuestionToDatePostedMapping = new ();
            void ProcessQuestion(Question question) => iQuestionToDatePostedMapping[question] = question.DatePosted;
            currentQuestions.ForEach(ProcessQuestion);
            Dictionary<Question, DateTime> sortedMap = iQuestionToDatePostedMapping.OrderBy(keyValuePair => keyValuePair.Value).ToDictionary();
            return sortedMap.Keys.ToList();
        }

        public List<Question> SortQuestionsByDateDescending()
        {
            List<Question> questions = SortQuestionsByDateAscending();
            questions.Reverse();
            return questions;
        }

        public List<Category> GetAllCategories() => repository.GetAllCategories().ToList();

        public List<Question> GetCurrentQuestions() => currentQuestions;

        public List<Answer> GetAnswersOfUser(long userId) => repository.GetAnswersOfUser(userId).ToList();

        public List<Question> GetQuestionsOfUser(long userId)
        {
            return repository.GetQuestionsOfUser(userId).ToList();
        }

        public List<Comment> GetCommentsOfUser(long userId) => repository.GetCommentsOfUser(userId).ToList();

        public List<Tag> GetTagsOfQuestion(long questionId) => repository.GetTagsOfQuestion(questionId).ToList();

        public void AddQuestion(string title, string content, Category category)
        {
            long userID = IDGenerator.RandomLong();
            long questionId = IDGenerator.RandomLong();
            Question question = new QuestionBuilder().Begin().SetId(questionId).SetUserId(userID).SetContent(content).SetCategory(category).SetTitle(title).End();
            repository.AddQuestion(question);
        }

        public void AddQuestionByObject(Question question)
        {
            repository.AddQuestion(question);
        }

        public List<Badge> GetBadgesOfUser(long userId)
        {
            return repository.GetBadgesOfUser(userId).ToList();
        }
        public int CountQuestionsInLast7Days()
        {
            List<Question> questionsWithinLast7Days = GetAllQuestions()
                .Where(question => question.DatePosted >= DateTime.Now.AddDays(-7) && question.DatePosted <= DateTime.Now)
                .ToList();

            return questionsWithinLast7Days.Count;
        }

        public int FilterQuestionsAnsweredThisMonth()
        {
            DateTime currentDate = DateTime.Now;
            DateTime firstDayOfMonth = new (currentDate.Year, currentDate.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            bool QuestionIsPostedWithinLastCalendarMonth(IQuestion question) => question.DatePosted >= firstDayOfMonth && question.DatePosted <= lastDayOfMonth;
            return GetAllQuestions()
                .Where(QuestionIsPostedWithinLastCalendarMonth)
                .Count();
        }

        public int FilterQuestionsAnsweredLastYear()
        {
            const int JANUARY = 1;
            const int DECEMBER = 12;
            const int FIRST_DAY_OF_MONTH = 1;
            const int LAST_DAY_OF_DECEMBER = 31;
            DateTime currentDate = DateTime.Now;
            DateTime firstDayOfLastYear = new (currentDate.Year - 1, JANUARY, FIRST_DAY_OF_MONTH);
            DateTime lastDayOfLastYear = new (currentDate.Year - 1, DECEMBER, LAST_DAY_OF_DECEMBER);
            bool QuestionIsPostedWithinPreviousCalendarYear(Question question) => question.DatePosted >= firstDayOfLastYear && question.DatePosted <= lastDayOfLastYear;
            return GetAllQuestions()
                .Where(QuestionIsPostedWithinPreviousCalendarYear)
                .Count();
        }
    }
}