using CodeBuddies.Models.Entities.Interfaces;

namespace CodeBuddies.Models.Entities
{
    public class DrawingBoard : IDrawingBoard
    {
        #region Properties
        public string FilePath { get; set; }
        #endregion
        #region Constructors
        public DrawingBoard()
        {
            FilePath = string.Empty;
        }

        public DrawingBoard(string filePath)
        {
            FilePath = filePath;
        }
        #endregion
    }
}
