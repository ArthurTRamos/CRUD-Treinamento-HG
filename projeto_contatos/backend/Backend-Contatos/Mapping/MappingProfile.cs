using AutoMapper;
using Backend_Contatos.Models;
using Backend_Contatos.Models.DTOs;

namespace Backend_Contatos.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact, ContactDTO>().ReverseMap();

            CreateMap<CreateContactDTO, Contact>();

            CreateMap<UpdateContactDTO, Contact>();
        }
    }
}
