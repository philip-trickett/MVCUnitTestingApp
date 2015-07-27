﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCUnitTesting;
using MVCUnitTesting.Controllers;
using MVCUnitTesting.Models;
using Telerik.JustMock;

namespace MVCUnitTesting.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void FindByGenreReturnsAllInGenre()
        {
            //Arrange
            var productRepository = Mock.Create<Repository>();
            Mock.Arrange(()=> productRepository.GetAll()).Returns(
                new List<Product>()
                {
                    new Product(){Genre = "Fiction", ID=1, Name="Moby Dick", Price=12.50m},
                    new Product(){Genre = "Fiction", ID=2, Name="War and Peace", Price=22.50m},
                    new Product(){Genre = "Non-Fiction", ID=3, Name="Chemicals", Price=35m}
                }).MustBeCalled();

            HomeController controller = new HomeController(productRepository);
            ViewResult viewResult = controller.FindByGenre("Fiction");
            var model = viewResult.Model as IEnumerable<Product>;

            //Assert
            Assert.AreEqual(2, model.Count());
            Assert.AreEqual("Moby Dick", model.ToList()[0].Name);
            Assert.AreEqual("War and Peace", model.ToList()[1].Name);
        }

        [TestMethod]
        public void Index_Returns_All_Products_In_DB()
        {
            //Arrange
            var productRepository = Mock.Create<Repository>();
            Mock.Arrange( () => productRepository.GetAll() )
                .Returns(new List<Product>()
                {
                    new Product() {Genre = "Fiction", ID = 1, Name = "Moby Dick", Price = 12.50m},
                    new Product() {Genre = "Fiction", ID = 2, Name = "War and Peace", Price = 17m}
                }).MustBeCalled();
            
            //Act
            HomeController controller = new HomeController(productRepository);
            ViewResult viewResult = controller.Index();
            var model = viewResult.Model as IEnumerable<Product>;

            //Assert
            Assert.AreEqual(2, model.Count());
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
