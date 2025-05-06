using DotNetNuke.Web.Api;
using System.Web.Http;
using Dancers.Dnn.Dnn_DancersChoice_Meret.Models;

namespace Dancers.Dnn.Dnn_DancersChoice_Meret.Controllers
{
    public class SizeApiController : DnnApiController
    {
        [HttpPost]
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
            if (weight == "41-60" && height == "141-160") return "XS";
            if (weight == "61-80" && height == "161-170") return "S";
            if (weight == "81-100" && height == "171-190") return "M";
            if (weight == "101-120" && height == "191-210") return "L";
            if (weight == "121-200" && height == "211-250") return "XL";

            return "Ismeretlen";
        }
    }
}
