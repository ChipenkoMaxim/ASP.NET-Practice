﻿using System;
using System.Collections.Generic;
using SportStore.Domain.Entities;
using System.Linq;
using System.Web;

namespace SportStore.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public String CurrentCategory { get; set; }
    }
}