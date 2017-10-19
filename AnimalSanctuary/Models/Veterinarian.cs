using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AnimalSanctuary.Models
{
    [Table("Veterinarians")]
    public class Veterinarian
    {
        [Key]
        public int VeterinarianId { get; set; }
        public string Name { get;  set; }
        public string Speciality { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }

        public override bool Equals(System.Object otherVet)
        {
            if (!(otherVet is Veterinarian))
            {
                return false;
            }
            else
            {
                Veterinarian newVet = (Veterinarian)otherVet;
                return this.VeterinarianId.Equals(newVet.VeterinarianId);

            }
        }

        public override int GetHashCode()
        {

            return this.VeterinarianId.GetHashCode();
        }

        public static void DeleteAll()
        {
            AnimalSanctuaryContext db = new AnimalSanctuaryContext();
            db.Veterinarians.RemoveRange(db.Veterinarians.ToList());

            db.SaveChanges();
        }
    }
}
