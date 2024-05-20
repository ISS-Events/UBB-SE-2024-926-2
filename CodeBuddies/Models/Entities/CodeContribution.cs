using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Utils;

namespace CodeBuddies.Models.Entities
{
    public class CodeContribution : ICodeContribution
    {
        #region Properties
        public long Contributor { get; set; }
        public DateTime ContributionDate { get; set; }
        public int ContributionValue { get; set; }
        #endregion
        #region Constructors
        public CodeContribution()
        {
            Contributor = IDGenerator.Default();
            ContributionDate = DateTime.Now;
            ContributionValue = 0;
        }
        public CodeContribution(long contributor, DateTime date, int contributionValue)
        {
            Contributor = contributor;
            ContributionDate = date;
            ContributionValue = contributionValue;
        }
        #endregion
    }
}
