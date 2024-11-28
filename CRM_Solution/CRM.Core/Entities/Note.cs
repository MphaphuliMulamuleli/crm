namespace CRM.Core.Entities
{
    public class Note
    {
        public int NoteId { get; set; }
        public int ClientId { get; set; }
        public required string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        public Client Client { get; set; } = null!;
    }
} 