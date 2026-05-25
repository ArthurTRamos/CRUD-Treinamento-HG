using Backend_Contatos.Models;

namespace Backend_Contatos.Repositories
{
    /// <summary>
    /// Interface that defines the contract for Contact data access operations
    /// Principle: Dependency Inversion - depend on abstractions
    /// </summary>
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactByIDAsync(int id);
        Task<Contact> CreateContactAsync(Contact contact);
        Task<Contact> UpdateContactAsync(Contact contact);
        Task<bool> DeleteContactAsync(int id);
        Task<bool> SaveAsync();
    }
}