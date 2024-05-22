using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Utils;

namespace CodeBuddies.Models.Entities
{
    public class DrawingBoard : IDrawingBoard
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
        #region Methods

        /// <summary>
        /// Draw a point at x, y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Draw(int x, int y)
        {
            // Draw the point at x, y
        }

        /// <summary>
        /// Save the drawing to the file
        /// </summary>
        public void Save()
        {
            // Save the drawing to the file
        }

        /// <summary>
        /// Render the drawing
        /// </summary>
        public void Render()
        {
            // Render the drawing
        }

        /// <summary>
        /// Erase the point at x, y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Erase(int x, int y)
        {
            // Erase the point at x, y
        }
        #endregion
    }
}
