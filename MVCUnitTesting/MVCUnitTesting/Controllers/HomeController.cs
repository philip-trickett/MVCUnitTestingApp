﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCUnitTesting.Models;

namespace MVCUnitTesting.Controllers
{
    public class HomeController : Controller
    {
        private Repository repository;

        public HomeController(Repository repository)
        {
            this.repository = repository;
        }

        public HomeController()
        {
            this.repository = new WorkingProductRepository();
        }

        public ViewResult FindByGenre(string genre)
        {
            var products = repository.GetAll();
            List<Product> results = products.Where(b => b.Genre == genre).ToList();
            return View(results);
        }

        public ViewResult Index()
        {
            var products = repository.GetAll();
            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Message = "Your create page.";

            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Message = "Your Edit page.";

            return View();
        }

        public ActionResult Details(int id)
        {
            ViewBag.Message = "Your Details page.";

            return View();
        }

        public ActionResult Delete(int id)
        {
            ViewBag.Message = "Your Delete page.";

            return View();
        }
    }
}