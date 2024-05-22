namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface ICodeContribution
    {
        #region Properties
        long Id { get; set; }
        DateTime ContributionDate { get; set; }
        int ContributionValue { get; set; }
        long Contributor { get; set; }
        #endregion
    }
}