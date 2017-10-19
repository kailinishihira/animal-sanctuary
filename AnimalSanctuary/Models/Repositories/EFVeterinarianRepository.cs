using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AnimalSanctuary.Models.Repositories
{
    public class EFVeterinarianRepository : IVeterinarianRepository
    {
        public EFVeterinarianRepository(AnimalSanctuaryContext connection = null)
        {
            if (connection == null)
            {
                this.db = new AnimalSanctuaryContext();
            }
            else
            {
                this.db = connection;
            }
        }
        AnimalSanctuaryContext db = new AnimalSanctuaryContext();

        public IQueryable<Veterinarian> Veterinarians
        { get { return db.Veterinarians; } }

        public Veterinarian Edit(Veterinarian vet)
        {
            db.Entry(vet).State = EntityState.Modified;
            db.SaveChanges();
            return vet;
        }

        public void Remove(Veterinarian vet)
        {
            db.Veterinarians.Remove(vet);
            db.SaveChanges();
        }

        public Veterinarian Save(Veterinarian vet)
        {
            db.Veterinarians.Add(vet);
            db.SaveChanges();
            return vet;
        }

        public void DeleteAll()
        {
            db.Veterinarians.RemoveRange(db.Veterinarians.ToList());
            db.SaveChanges();
        }
    }
}
