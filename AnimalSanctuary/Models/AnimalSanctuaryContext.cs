using Microsoft.EntityFrameworkCore;

namespace AnimalSanctuary.Models
{
    public class AnimalSanctuaryContext : DbContext
    {
        public virtual DbSet<Animal> Animals { get; set; } 
        public virtual DbSet<Veterinarian> Veterinarians { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseMySql(@"Server=localhost;Port=8889;database=animalSanctuary;uid=root;pwd=root;");
    }
}
