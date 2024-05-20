namespace CodeBuddies.Models.Entities
{
    public interface ITag
    {
        #region Properties
        long Id { get; set; }
        string Name { get; set; }
        string ToString() => $"ITag {{id: {Id}, name: {Name}}}";
        #endregion
    }
}