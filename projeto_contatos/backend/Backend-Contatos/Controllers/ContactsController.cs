using Backend_Contatos.Models.DTOs;
using Backend_Contatos.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Contatos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(IContactService contactService, ILogger<ContactsController> logger)
        {
            _contactService = contactService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDTO>>> GetAllContacts()
        {
            _logger.LogInformation("GET /api/contacts - fetching all contacts");
            var contacts = await _contactService.GetAllContactsAsync();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDTO>> GetContactById(int id)
        {
            _logger.LogInformation($"GET /api/contacts/{id} - fetching contact");

            var contact = await _contactService.GetContactByIdAsync(id);

            if (contact == null)
            {
                _logger.LogWarning($"Contact with Id {id} not found");
                return NotFound(new { mensagem = $"Contact with Id {id} not found" });
            }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<ActionResult<ContactDTO>> CreateContact([FromBody] CreateContactDTO createContactDto)
        {
            _logger.LogInformation("POST /api/contacts - creating contact");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdContact = await _contactService.CreateContactAsync(createContactDto);

                return CreatedAtAction(nameof(GetContactById), new { id = createdContact.Id }, createdContact);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ContactDTO>> UpdateContact(int id, [FromBody] UpdateContactDTO updateContactDto)
        {
            _logger.LogInformation($"PUT /api/contacts/{id} - updating contact");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedContact = await _contactService.UpdateContactAsync(id, updateContactDto);

                if (updatedContact == null)
                {
                    return NotFound(new { mensagem = $"Contact with Id {id} not found" });
                }

                return Ok(updatedContact);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            _logger.LogInformation($"DELETE /api/contacts/{id} - deleting contact");

            var result = await _contactService.DeleteContactAsync(id);

            if (!result)
            {
                return NotFound(new { mensagem = $"Contact with Id {id} not found" });
            }

            return Ok(new { mensagem = $"Contact {id} deleted successfully" });
        }
    }
}