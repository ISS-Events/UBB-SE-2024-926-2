namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface ITextEditor
    {
        #region Properties
        long Id { get; set; }
        List<string> FilePaths { get; set; }
        string TextColor { get; set; }
        #endregion
    }
}