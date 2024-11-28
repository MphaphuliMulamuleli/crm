namespace CRM.Core.Interfaces
{
    using CRM.Core.Entities;

    public interface IClientRepository
    {
        Task<Client> GetByIdAsync(int id);
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client> AddAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(int id);
        Task UpdateClientTypeAsync(int clientId, int newClientTypeId);
    }
}