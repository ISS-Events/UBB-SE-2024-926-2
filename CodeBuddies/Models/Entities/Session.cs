using CodeBuddies.Models.Entities.Interfaces;
using CodeBuddies.Utils;

namespace CodeBuddies.Models.Entities
{
    public class Session : ISession
    {
        #region Properties
        public long Id { get; set; }
        public long OwnerId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }
        public List<long> Buddies { get; set; }
        public List<Message> Messages { get; set; }
        public List<CodeContribution> CodeContributions { get; set; }
        public List<CodeReviewSection> CodeReviewSections { get; set; }
        public List<string> FilePaths { get; set; }
        public TextEditor TextEditor { get; set; }
        public DrawingBoard DrawingBoard { get; set; }
        #endregion
        #region Constructors
        public Session(long sessionId,
                       long ownerId,
                       string name,
                       DateTime creationDate,
                       DateTime lastEditedDate,
                       List<long> buddies,
                       List<Message> messages,
                       List<CodeContribution> codeContributions,
                       List<CodeReviewSection> codeReviewSections,
                       List<string> filePaths,
                       TextEditor textEditor,
                       DrawingBoard drawingBoard)
        {
            Id = sessionId;
            OwnerId = ownerId;
            Name = name;
            CreationDate = creationDate;
            LastEditDate = lastEditedDate;
            Buddies = buddies;
            Messages = messages;
            CodeContributions = codeContributions;
            CodeReviewSections = codeReviewSections;
            FilePaths = filePaths;
            TextEditor = textEditor;
            DrawingBoard = drawingBoard;
        }
        public Session()
        {
            Id = IDGenerator.Default();
            OwnerId = IDGenerator.Default();
            Name = string.Empty;
            CreationDate = DateTime.Now;
            LastEditDate = DateTime.Now;
            Buddies = new ();
            Messages = new ();
            CodeContributions = new ();
            CodeReviewSections = new ();
            FilePaths = new ();
            TextEditor = new ();
            DrawingBoard = new ();
        }
        #endregion
    }
}