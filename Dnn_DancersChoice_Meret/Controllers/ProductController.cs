using Hotcakes.Commerce.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Mvc;
using Dancers.Dnn.Dnn_DancersChoice_Meret.Models;


namespace Dancers.Dnn.Dnn_DancersChoice_Meret.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index(string category)
        {
            var filePath = HostingEnvironment.MapPath("~/DesktopModules/MVC/Dnn_DancersChoice_Meret/Adat/Hotcakes_Products.csv");
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
                .ToList();

            return View(products);
        }
    }

}
