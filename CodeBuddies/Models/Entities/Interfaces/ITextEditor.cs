namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface ITextEditor
    {
        #region Properties
        List<string> FilePaths { get; set; }
        string TextColor { get; set; }
        #endregion
        #region Methods
        void Delete(int row, int column);
        void Insert(int row, int column, string text);
        void OpenFile(string filePath);
        void SelectSelection(int startRow, int startColumn, int endRow, int endColumn);
        #endregion
    }
}