using System.Linq;
using AnimalSanctuary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimalSanctuary.Controllers
{
    public class AnimalsController : Controller
    {
        private IAnimalRepository animalRepo;
        public AnimalsController(IAnimalRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.animalRepo = new EFAnimalRepository();

            }
            else
            {
                this.animalRepo = thisRepo;
            }
        }

        public IActionResult Index()
        {
            var animalList = animalRepo.Animals.ToList();
            return View(animalList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Animal animal)
        {
            animalRepo.Save(animal);
            return View();
        }

        public IActionResult Details(int animalId)
        {
            var thisAnimal = animalRepo.Animals.Include(animal => animal.Veterinarian)
                               .FirstOrDefault(x => x.AnimalId == animalId);
            return View(thisAnimal);
        }

        public IActionResult Edit(int animalId)
        {
            var thisAnimal = animalRepo.Animals.FirstOrDefault(x => x.AnimalId == animalId);
            return View(thisAnimal);
        }

        [HttpPost]
        public IActionResult Edit(Animal animal)
        {
            animalRepo.Edit(animal);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int animalId)
        {
            var thisAnimal = animalRepo.Animals.FirstOrDefault(x => x.AnimalId == animalId);
            return View(thisAnimal);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmation(int animalId)
        {
            var thisAnimal = animalRepo.Animals.FirstOrDefault(x => x.AnimalId == animalId);
            animalRepo.Remove(thisAnimal);
            return RedirectToAction("Index");
        }

    }
}
