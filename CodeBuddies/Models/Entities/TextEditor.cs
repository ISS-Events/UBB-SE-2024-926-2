using CodeBuddies.Models.Entities.Interfaces;

namespace CodeBuddies.Models.Entities
{
    public class TextEditor : ITextEditor
    {
        #region Properties
        public string TextColor { get; set; }
        public List<string> FilePaths { get; set; }
        #endregion
        #region Constructors
        public TextEditor()
        {
            TextColor = string.Empty;
            FilePaths = new ();
        }
        public TextEditor(string textColor, List<string> filesPaths)
        {
            TextColor = textColor;
            FilePaths = filesPaths;
        }
        #endregion
    }
}
