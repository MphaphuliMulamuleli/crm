namespace CRM.Core.Entities
{
    public class Title
    {
        public int TitleId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        
        public ICollection<Client> Clients { get; set; } = new List<Client>();
    }
} 