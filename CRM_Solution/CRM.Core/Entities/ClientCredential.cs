namespace CRM.Core.Entities
{
    public class ClientCredential
    {
        public int ClientCredentialId { get; set; }
        public int ClientId { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        public Client Client { get; set; } = null!;
    }
} 