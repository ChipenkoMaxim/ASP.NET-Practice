﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SportStore.Domain.Entities;
using System.Web;

namespace SportStore.WebUI.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const String sessionKey = "Cart";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            if (cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }
            return cart;
        }
    }
}