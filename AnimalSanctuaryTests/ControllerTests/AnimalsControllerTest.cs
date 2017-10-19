using AnimalSanctuary.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalSanctuary.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Moq;
using AnimalSanctuaryTests.Models;
using AnimalSanctuary.Models.Repositories;

namespace AnimalSanctuaryTests
{
    [TestClass]
    public class AnimalsControllerTest : IDisposable
    {
        Mock<IAnimalRepository> mock = new Mock<IAnimalRepository>();
        EFAnimalRepository db = new EFAnimalRepository(new TestDbContext());
        EFVeterinarianRepository db2 = new EFVeterinarianRepository(new TestDbContext());


        private void DbSetup()
        {
                mock.Setup(m => m.Animals).Returns(new Animal[]{
                new Animal(){AnimalId =1, Name = "Momo", Species = "Spider Monkey", Sex = "Female", HabitType = "Forest", MedicalEmergency = false, VeterinarianId = 1},
                new Animal(){AnimalId =2, Name = "Mimi", Species = "Giant Panda", Sex = "Female", HabitType = "Forest", MedicalEmergency = false, VeterinarianId = 1},
                new Animal(){AnimalId =3, Name = "Mika", Species = "Monkey", Sex = "Male", HabitType = "Forest", MedicalEmergency = true, VeterinarianId = 1}
            }.AsQueryable());
        }

        public void Dispose()
        {
            db.DeleteAll();
        }


        [TestMethod]
        public void Mock_GetViewResultIndex_Test()
        {
            DbSetup();
            //Arrange
            AnimalsController controller = new AnimalsController(mock.Object);
            //Act
            var result = controller.Index();
            //Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void Mock_IndexListOfAnimals_Test()
        {
            DbSetup();
            //Arrange
            ViewResult indexView = new AnimalsController(mock.Object).Index() as ViewResult;
            //Act
            var result = indexView.ViewData.Model;
            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Animal>));
        }

        [TestMethod]
        public void Mock_ConfirmEntry_Test()
        {
            DbSetup();
            AnimalsController controller = new AnimalsController(mock.Object);
            Animal testAnimal = new Animal();
            testAnimal.Name = "Momo";
            testAnimal.Species = "Spider Monkey";
            testAnimal.Sex = "Female";
            testAnimal.HabitType = "Forest";
            testAnimal.MedicalEmergency = false;
            testAnimal.VeterinarianId = 1;
            testAnimal.AnimalId = 1;

            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as List<Animal>;

            CollectionAssert.Contains(collection, testAnimal);
         }

        [TestMethod]
        public void DB_CreateNewEntry_Test()
        {
            //Arrange
            AnimalsController controller = new AnimalsController(db);
            VeterinariansController vetController = new VeterinariansController(db2);
            Veterinarian testVet = new Veterinarian()
            { VeterinarianId = 1, Name = "Mike", Speciality = "Mice" };
            Animal testAnimal = new Animal()
            { Name = "Momo", Species = "Spider Monkey", Sex = "Female", HabitType = "Forest", MedicalEmergency = false, VeterinarianId = 1 };
           

            //List<Animal> expected = new List<Animal>()
           //{ testAnimal };

            //Act
            vetController.Create(testVet);
            controller.Create(testAnimal);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Animal>;

            //Assert
            CollectionAssert.Contains(collection, testAnimal);
        }


        //[TestMethod]
        //public void TestCreateMethod()
        //{
        //    //Arrange
        //    Animal animal = new Animal()
        //    { Name = "Momo", Species = "Spider Monkey", Sex = "Female", HabitType = "Forest", MedicalEmergency = false, VeterinarianId = 1 };
        //    List<Animal> expected = new List<Animal>()
        //    {
        //        animal
        //    };

        //    //Act

        //    AnimalsController newController = new AnimalsController();
        //    newController.Create(animal);
           

        //    var actual = db.Animals.ToList();
        //    //Assert
        //    CollectionAssert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void TestEditMethod()
        //{
        //    //Arrange
        //    Animal animal = new Animal()
        //    { Name = "Momo", Species = "Spider Monkey", Sex = "Female", HabitType = "Forest", MedicalEmergency = false, VeterinarianId = 1 };
 
        //    //Act

        //    AnimalsController newController = new AnimalsController();
        //    newController.Create(animal);

        //    animal.Name = "Mimi";
        //    newController.Edit(animal);
        //    var expected = "Mimi";
     
        //    var actual = db.Animals.ToList()[0].Name;
        //    //Assert
        //    Assert.AreEqual(expected, actual);
        //}

        //[TestMethod]
        //public void TestDeleteMethod()
        //{
        //    Animal animal = new Animal()
        //    { Name = "Momo", Species = "Spider Monkey", Sex = "Female", HabitType = "Forest", MedicalEmergency = false, VeterinarianId = 1 };

        //    AnimalsController newController = new AnimalsController();
        //    newController.Create(animal);
        //    int animalId = db.Animals.ToList()[0].AnimalId;
        //    newController.DeleteConfirmation(animalId);
        //    var expected = 0;
        //    var actual = db.Animals.ToList().Count();

        //    Assert.AreEqual(expected, actual);
        //}

    }
}
