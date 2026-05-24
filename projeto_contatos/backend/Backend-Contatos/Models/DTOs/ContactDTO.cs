namespace Backend_Contatos.Models.DTOs
{
    public class CreateContactDTO
    {
        public string Name { get; set; }
        public string Number { get; set; }
    }

    public class UpdateContactDTO
    {
        public string Name { get; set; }
        public string Number { get; set; }
    }

    public class ContactDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
    }
}
