﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportStore.Domain.Abstract;

namespace SportStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductsRepository repository;
        public AdminController(IProductsRepository repo)
        {
           repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Products);
        }
    }
}