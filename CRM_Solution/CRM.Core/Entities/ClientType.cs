namespace CRM.Core.Entities
{
    public class ClientType
    {
        public int ClientTypeId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        
        public ICollection<Client> Clients { get; set; } = new List<Client>();
    }
} 