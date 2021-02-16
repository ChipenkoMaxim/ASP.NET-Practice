﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportStore.Domain.Abstract;

namespace SportStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductsRepository repository;
        public NavController(IProductsRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(String category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<String> categories = repository.Products
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}