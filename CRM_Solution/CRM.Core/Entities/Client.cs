namespace CRM.Core.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public int TitleId { get; set; }
        public int ClientTypeId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string ContactNumber { get; set; }
        public required string Address { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public Title Title { get; set; } = null!;
        public ClientType ClientType { get; set; } = null!;
        public ICollection<Note> Notes { get; set; } = new List<Note>();
        public ClientCredential? Credential { get; set; }
    }
}