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
