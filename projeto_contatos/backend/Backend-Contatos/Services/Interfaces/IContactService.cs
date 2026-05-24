using AutoMapper;
using Backend_Contatos.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Contatos.Services.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactDTO>> GetAllContactsAsync();
        Task<ContactDTO> GetContactByIdAsync(int id);
        Task<ContactDTO> CreateContactAsync(CreateContactDTO createContactDTO);
        Task<ContactDTO> UpdateContactAsync(int id, UpdateContactDTO updateContactDTO);
        Task<bool> DeleteContactAsync(int id);
    }
}