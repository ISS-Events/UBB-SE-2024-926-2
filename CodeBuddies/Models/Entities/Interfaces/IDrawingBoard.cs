namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface IDrawingBoard
    {
        #region Properties
        long Id { get; set; }
        string FilePath { get; set; }
        void Draw(int x, int y);
        void Erase(int x, int y);
        void Render();
        void Save();
        #endregion
    }
}