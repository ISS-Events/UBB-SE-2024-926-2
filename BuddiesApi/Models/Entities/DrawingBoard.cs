
using CodeBuddies.Utils;

namespace CodeBuddies.Models.Entities
{
    public class DrawingBoard : Interfaces.IDrawingBoard
    {
        #region Properties
        public long Id { get; set; }
        public string FilePath { get; set; }
        #endregion
        #region Constructors
        public DrawingBoard()
        {
            Id = IDGenerator.Default();
            FilePath = string.Empty;
        }

        public DrawingBoard(string filePath)
        {
            FilePath = filePath;
        }
        #endregion
    }
}
