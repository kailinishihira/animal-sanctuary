using Microsoft.EntityFrameworkCore;
using AnimalSanctuary.Models;

namespace AnimalSanctuaryTests.Models
{
    public class TestDbContext : AnimalSanctuaryContext
    {
        public override DbSet<Animal> Animals { get; set; }
        public override DbSet<Veterinarian> Veterinarians { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=animalSanctuary_test;uid=root;pwd=root;");
        }
    }
}
