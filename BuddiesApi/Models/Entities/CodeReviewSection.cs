
using CodeBuddies.Utils;

namespace CodeBuddies.Models.Entities
{
    public class CodeReviewSection : Interfaces.ICodeReviewSection
    {
        #region Properties
        public long Id { get; set; }
        public long OwnerId { get; set; }
        public List<Message> Messages { get; set; }
        public string CodeSection { get; set; }
        public bool IsClosed { get; set; }
        #endregion
        #region Constructors
        public CodeReviewSection()
        {
            Id = IDGenerator.Default();
            OwnerId = IDGenerator.Default();
            Messages = new List<Message>();
            CodeSection = string.Empty;
            IsClosed = false;
        }
        public CodeReviewSection(long codeReviewSectionId, long ownerId, List<Message> message, string codeSection, bool isClosed)
        {
            Id = codeReviewSectionId;
            OwnerId = ownerId;
            Messages = message;
            CodeSection = codeSection;
            IsClosed = isClosed;
        }
        #endregion
    }
}
