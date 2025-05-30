﻿using DotNetNuke.Web.Mvc.Framework.Controllers;
using System.Linq;
using System.Text;
using System.Web.Hosting;
using System.Web.Mvc;
using System;

namespace Dancers.Dnn.Dnn_DancersChoice_Meret.Controllers
{
    public class SizeWizardController : DnnController
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductSuggestions(string category)
        {
            var filePath = HostingEnvironment.MapPath("~/DesktopModules/MVC/Dnn_DancersChoice_Meret/data/Hotcakes_Products.csv");

            var lines = System.IO.File.ReadAllLines(filePath, Encoding.UTF8);

            var products = lines
                .Skip(1)
                .Select(line => line.Split(';'))
                .Where(parts => parts.Length >= 5)
                .Select(parts => new Dancers.Dnn.Dnn_DancersChoice_Meret.Models.Product
                {
                    Name = parts[0].Trim('"'),
                    Price = parts[1],
                    ImageUrl = parts[2],
                    Slug = parts[3],
                    Category = parts[4]
                })
                .Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .Take(4)
                .ToList();

            return PartialView("ProductSuggestions", products); // !!! EZ A FONTOS !!!
        }


    }
}
