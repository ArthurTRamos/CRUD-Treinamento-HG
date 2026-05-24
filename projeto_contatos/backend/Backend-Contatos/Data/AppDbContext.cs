using Microsoft.EntityFrameworkCore;
using Backend_Contatos.Models;

namespace Backend_Contatos.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet que mapeia a entidade Contact para a tabela "Contacts"
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade Contact
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Number)
                    .IsRequired();
            });
        }
    }
}
