namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface ICodeContribution
    {
        #region Properties
        DateTime ContributionDate { get; set; }
        int ContributionValue { get; set; }
        long Contributor { get; set; }
        #endregion
    }
}