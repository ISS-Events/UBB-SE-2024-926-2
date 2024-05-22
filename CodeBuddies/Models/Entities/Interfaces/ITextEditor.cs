namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface ITextEditor
    {
        #region Properties
        List<string> FilePaths { get; set; }
        string TextColor { get; set; }
        #endregion
    }
}