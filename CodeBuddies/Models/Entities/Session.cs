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
        public Session(long sessionId, long ownerId, string name, DateTime creationDate, DateTime lastEditedDate, List<long> buddies, List<IMessage> messages, List<ICodeContribution> codeContributions, List<ICodeReviewSection> codeReviewSections, List<string> filePaths, ITextEditor textEditor, IDrawingBoard drawingBoard)
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
            Buddies = new List<long> { };
            Messages = new List<IMessage> { };
            CodeContributions = new List<ICodeContribution> { };
            CodeReviewSections = new List<ICodeReviewSection> { };
            FilePaths = new List<string> { };
            TextEditor = new TextEditor();
            DrawingBoard = new DrawingBoard();
        }
        #endregion
        #region Methods

        /// <summary>
        /// Add buddy to the session
        /// </summary>
        /// <param name="buddyId"></param>
        public void AddBuddy(long buddyId)
        {
            // Add buddy to the session
            return;
        }

        /// <summary>
        /// Remove buddy from the session
        /// </summary>
        /// <param name="buddyId"></param>
        public void RemoveBuddy(long buddyId)
        {
            // Remove buddy from the session
            return;
        }

        /// <summary>
        /// Leave the session
        /// </summary>
        /// <param name="buddyId"></param>
        public void LeaveSession(long buddyId)
        {
            // Leave the session
            return;
        }

        /// <summary>
        /// Upload file to the session
        /// </summary>
        /// <param name="filePath"></param>
        public void UploadFile(string filePath)
        {
            FilePaths.Add(filePath);
        }

        /// <summary>
        /// Add code contribution
        /// </summary>
        /// <param name="buddyId"></param>
        /// <param name="date"></param>
        /// <param name="contributionValue"></param>
        public void AddCodeContribution(int buddyId, DateTime date, int contributionValue)
        {
            // Add code contribution
            return;
        }

        /// <summary>
        /// Post message to the session
        /// </summary>
        /// <param name="message"></param>
        public void PostMessage(Message message)
        {
            Messages.Add(message);
        }

        public void PostCodeReviewSection(CodeReviewSection codeReviewSection)
        {
            CodeReviewSections.Add(codeReviewSection);
        }

        #endregion
    }
}