using Microsoft.EntityFrameworkCore;
using Backend_Contatos.Data;
using Backend_Contatos.Models;
using Backend_Contatos.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Contatos.Repositories
{
    /// <summary>
    /// Repository Pattern implementation for the Contact entity
    /// Responsibility: Data access and persistence
    /// </summary>
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET Method - Safe and Idempotent
        /// Retrieves all contacts from the database
        /// </summary>
        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        /// <summary>
        /// GET Method - Safe and Idempotent
        /// Retrieves a specific contact by Id
        /// </summary>
        public async Task<Contact> GetContactByIDAsync(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// POST Method - Non-idempotent
        /// Creates a new contact in the database
        /// </summary>
        public async Task<Contact> CreateContactAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await SalvarAsync();
            return contact;
        }

        /// <summary>
        /// PUT Method - Idempotent
        /// Updates an existing contact
        /// </summary>
        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            var contactExisting = await _context.Contacts.FirstOrDefaultAsync(p => p.Id == contact.Id);

            if (contactExisting == null)
                return null;

            contactExisting.Name = contact.Name;
            contactExisting.Number = contact.Number;

            _context.Contacts.Update(contactExisting);
            await SalvarAsync();
            return contactExisting;
        }

        /// <summary>
        /// DELETE Method - Idempotent
        /// Deletes a contact from the database
        /// </summary>
        public async Task<bool> DeleteContactAsync(int id)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(p => p.Id == id);

            if (contact == null)
                return false;

            _context.Contacts.Remove(contact);
            await SalvarAsync();
            return true;
        }

        /// <summary>
        /// Saves all changes to the context
        /// </summary>
        public async Task<bool> SalvarAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}