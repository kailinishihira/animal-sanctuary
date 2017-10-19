using System.Linq;
using AnimalSanctuary.Models;
using AnimalSanctuary.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimalSanctuary.Controllers
{
    public class VeterinariansController : Controller
    {
        private IVeterinarianRepository vetRepo;
        public VeterinariansController(IVeterinarianRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.vetRepo = new EFVeterinarianRepository();

            }
            else
            {
                this.vetRepo = thisRepo;
            }
        }

        public IActionResult Index()
        {
            var vetList = vetRepo.Veterinarians.ToList();
            return View(vetList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Veterinarian veterinarian)
        {
            vetRepo.Save(veterinarian);
            return View();
        }

        public IActionResult Details(int veterinarianId)
        {
            var thisVet = vetRepo.Veterinarians
                                    .FirstOrDefault(x => x.VeterinarianId == veterinarianId);
            return View(thisVet);
        }

        public IActionResult Edit(int veterinarianId)
        {
            var thisVet = vetRepo.Veterinarians.FirstOrDefault(x => x.VeterinarianId == veterinarianId);
            return View(thisVet);
        }

        [HttpPost]
        public IActionResult Edit(Veterinarian veterinarian)
        {
            vetRepo.Edit(veterinarian);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int veterinarianId)
        {
            var thisVet = vetRepo.Veterinarians.FirstOrDefault(x => x.VeterinarianId == veterinarianId);
            return View(thisVet);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmation(int veterinarianId)
        {
            var thisVet = vetRepo.Veterinarians.FirstOrDefault(x => x.VeterinarianId == veterinarianId);
            vetRepo.Remove(thisVet);
            return RedirectToAction("Index");
        }

    }
}
