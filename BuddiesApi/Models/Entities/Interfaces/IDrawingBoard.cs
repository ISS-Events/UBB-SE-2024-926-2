namespace CodeBuddies.Models.Entities.Interfaces
{
    public interface IDrawingBoard
    {
        #region Properties
        long Id { get; set; }
        string FilePath { get; set; }
        #endregion
    }
}