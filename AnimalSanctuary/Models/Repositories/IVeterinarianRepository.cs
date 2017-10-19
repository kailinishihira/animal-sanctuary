using System;
using System.Linq;

namespace AnimalSanctuary.Models.Repositories
{
    public interface IVeterinarianRepository
    {
        IQueryable<Veterinarian> Veterinarians { get; }
        Veterinarian Save(Veterinarian vet);
        Veterinarian Edit(Veterinarian vet);
        void Remove(Veterinarian vet);
    }
}
