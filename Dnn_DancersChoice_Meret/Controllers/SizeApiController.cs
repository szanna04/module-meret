using DotNetNuke.Web.Api;
using System.Web.Http;
using Dancers.Dnn.Dnn_DancersChoice_Meret.Models;
using System.Text;
using System.Web.Hosting;
using System.IO;
using System;
using System.Linq;


namespace Dancers.Dnn.Dnn_DancersChoice_Meret.Controllers
{
    public class SizeApiController : DnnApiController
    {
        [HttpPost]
        [AllowAnonymous]
        public IHttpActionResult GetRecommendedSize(SizeInput input)
        {
            string size = DetermineSize(input);
            return Ok(new { size });
        }

        private string DetermineSize(SizeInput input)
        {
            string weight = input.Weight;
            string height = input.Height;

            if (weight == "30-40" && height == "100-140") return "XXS";
            if (weight == "41-60" && height == "100-140") return "XXS";
            if (weight == "41-60" && height == "141-160") return "XS";
            if (weight == "41-60" && height == "161-170") return "XS";
            if (weight == "61-80" && height == "161-170") return "S";
            if (weight == "41-60" && height == "141-160") return "S";
            if (weight == "81-100" && height == "171-190") return "M";
            if (weight == "30-40" && height == "161-170") return "M";
            if (weight == "101-120" && height == "191-210") return "L";
            if (weight == "101-120" && height == "171-190") return "L";
            if (weight == "121-200" && height == "211-250") return "XL";
            if (weight == "121-200" && height == "191-210") return "XL";

            return "Ismeretlen";
        }

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetProducts(string category)
        {
            try
            {
                var filePath = HostingEnvironment.MapPath("~/DesktopModules/MVC/Dnn_DancersChoice_Meret/Adat/Hotcakes_Products.csv");

                var lines = File.ReadAllLines(filePath, Encoding.UTF8);

                var products = lines
                    .Skip(1)
                    .Select(line => line.Split(';'))
                    .Where(parts => parts.Length >= 5)
                    .Select(parts => new Product
                    {
                        Name = parts[0].Trim('"'),
                        Price = parts[1],
                        ImageUrl = parts[2],
                        Slug = parts[3],
                        Category = parts[4].Trim()
                    })
                    .Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                    .Take(4)
                    .ToList();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}

