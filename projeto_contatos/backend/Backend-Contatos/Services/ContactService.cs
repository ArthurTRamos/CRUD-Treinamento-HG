using AutoMapper;
using System.Text.RegularExpressions;
using Backend_Contatos.Models;
using Backend_Contatos.Models.DTOs;
using Backend_Contatos.Repositories;
using Backend_Contatos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Contatos.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ContactService> _logger;
        public ContactService(IContactRepository contactRepository, IMapper mapper, ILogger<ContactService> logger)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ContactDTO>> GetAllContactsAsync()
        {
            try
            {
                _logger.LogInformation("Getting all contacts");
                var contacts = await _contactRepository.GetAllContactsAsync();
                return _mapper.Map<IEnumerable<ContactDTO>>(contacts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching contact: {ex.Message}");
                throw;
            }
        }

        public async Task<ContactDTO> GetContactByIdAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Getting contact with Id: {id}");
                var contact = await _contactRepository.GetContactByIDAsync(id);

                if (contact == null)
                {
                    _logger.LogWarning($"Contact with Id {id} not found");
                    return null;
                }

                return _mapper.Map<ContactDTO>(contact);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting contact {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<ContactDTO> CreateContactAsync(CreateContactDTO createContactDTO)
        {
            try
            {
                // Business validations
                if (string.IsNullOrWhiteSpace(createContactDTO.Name))
                    throw new ArgumentException("Contact name cannot be empty");

                if (!Regex.IsMatch(createContactDTO.Name, @"^[a-zA-ZÀ-ÿ0-9\s]+$"))
                    throw new ArgumentException("Contact name must be alphanumeric");

                if (string.IsNullOrWhiteSpace(createContactDTO.Number))
                    throw new ArgumentException("Contact number cannot be empty");

                if (!Regex.IsMatch(createContactDTO.Number, @"^[0-9]+$"))
                    throw new ArgumentException("Contact number must contain only digits");

                _logger.LogInformation($"Creating new contact: {createContactDTO.Name}");

                var contact = _mapper.Map<Contact>(createContactDTO);
                var contactCreated = await _contactRepository.CreateContactAsync(contact);

                _logger.LogInformation($"Contact created successfully. Id: {contactCreated.Id}");
                return _mapper.Map<ContactDTO>(contactCreated);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating contact: {ex.Message}");
                throw;
            }
        }

        public async Task<ContactDTO> UpdateContactAsync(int id, UpdateContactDTO updateContactDTO)
        {
            try
            {
                // Business validations
                if (string.IsNullOrWhiteSpace(updateContactDTO.Name))
                    throw new ArgumentException("Contact name cannot be empty");

                if (!Regex.IsMatch(updateContactDTO.Name, @"^[a-zA-ZÀ-ÿ0-9\s]+$"))
                    throw new ArgumentException("Contact name must be alphanumeric");

                if (string.IsNullOrWhiteSpace(updateContactDTO.Number))
                    throw new ArgumentException("Contact number cannot be empty");

                if (!Regex.IsMatch(updateContactDTO.Number, @"^[0-9]+$"))
                    throw new ArgumentException("Contact number must contain only digits");

                _logger.LogInformation($"Updating contact with Id: {id}");

                var contactExisting = await _contactRepository.GetContactByIDAsync(id);

                if (contactExisting == null)
                {
                    _logger.LogWarning($"Contact with Id {id} not found for update");
                    return null;
                }

                _mapper.Map(updateContactDTO, contactExisting);
                var contactUpdated = await _contactRepository.UpdateContactAsync(contactExisting);

                _logger.LogInformation($"Contact {id} updated successfully");
                return _mapper.Map<ContactDTO>(contactUpdated);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating contact {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteContactAsync(int id)
        {
            try
            {
                _logger.LogInformation($"Deleting contact with Id: {id}");
                var result = await _contactRepository.DeleteContactAsync(id);

                if (!result)
                {
                    _logger.LogWarning($"Contact with Id {id} not found for deletion");
                    return false;
                }

                _logger.LogInformation($"Contact {id} deleted successfully");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting contact {id}: {ex.Message}");
                throw;
            }

        }
    }
}