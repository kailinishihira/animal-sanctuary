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
    public class VeterinarianControllerTest : IDisposable
    {
        Mock<IVeterinarianRepository> mock = new Mock<IVeterinarianRepository>();
        EFVeterinarianRepository db = new EFVeterinarianRepository(new TestDbContext());

        private void DbSetup()
        {
            mock.Setup(m => m.Veterinarians).Returns(new Veterinarian[]{
                new Veterinarian(){VeterinarianId = 1, Name = "Mike", Speciality = "Mice"},
                new Veterinarian(){VeterinarianId = 2, Name = "Miko", Speciality = "Rat"},
                new Veterinarian(){VeterinarianId = 3, Name = "Miki", Speciality = "Rabit"}
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
            VeterinariansController controller = new VeterinariansController(mock.Object);
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
            ViewResult indexView = new VeterinariansController(mock.Object).Index() as ViewResult;
            //Act
            var result = indexView.ViewData.Model;
            //Assert
            Assert.IsInstanceOfType(result, typeof(List<Veterinarian>));
        }

        [TestMethod]
        public void Mock_ConfirmEntry_Test()
        {
            DbSetup();
            VeterinariansController controller = new VeterinariansController(mock.Object);
            Veterinarian testVet = new Veterinarian();
            testVet.Name = "Mike";
            testVet.Speciality = "Mice";
            testVet.VeterinarianId = 1;


            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as List<Veterinarian>;
            CollectionAssert.Contains(collection, testVet);
        }

        [TestMethod]
        public void DB_CreateNewEntry_Test()
        {
            //Arrange
            VeterinariansController controller = new VeterinariansController(db);
            Veterinarian testVet = new Veterinarian()
            { VeterinarianId = 1, Name = "Mike", Speciality = "Mice"};
            //List<Animal> expected = new List<Animal>()
            //{ testAnimal };

            //Act
            controller.Create(testVet);
            var collection = (controller.Index() as ViewResult).ViewData.Model as List<Veterinarian>;

            //Assert
            CollectionAssert.Contains(collection, testVet);
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
