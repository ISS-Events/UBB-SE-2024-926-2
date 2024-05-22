using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Utils;

namespace CodeBuddies.Models.Entities
{
    public class TextEditor : ITextEditor
    {
        #region Properties
        public long Id { get; set; }
        public string TextColor { get; set; }
        public List<string> FilePaths { get; set; }
        #endregion
        #region Constructors
        public TextEditor()
        {
            Id = IDGenerator.Default();
            TextColor = string.Empty;
            FilePaths = new List<string>();
        }
        public TextEditor(string textColor, List<string> filesPaths)
        {
            TextColor = textColor;
            FilePaths = filesPaths;
        }
        #endregion
        #region Methods

        /// <summary>
        /// Insert text at row, column
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="text"></param>
        public void Insert(int row, int column, string text)
        {
            // Insert text at row, column
        }

        /// <summary>
        /// Delete text at row, column
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public void Delete(int row, int column)
        {
            // Delete at row, column
        }

        /// <summary>
        /// Select the text from startRow, startColumn to endRow, endColumn
        /// </summary>
        /// <param name="startRow"></param>
        /// <param name="startColumn"></param>
        /// <param name="endRow"></param>
        /// <param name="endColumn"></param>
        public void SelectSelection(int startRow, int startColumn, int endRow, int endColumn)
        {
            // Select the text from startRow, startColumn to endRow, endColumn
        }

        /// <summary>
        /// Open the file
        /// </summary>
        /// <param name="filePath"></param>
        public void OpenFile(string filePath)
        {
            // Open the file
        }
        #endregion
    }
}
