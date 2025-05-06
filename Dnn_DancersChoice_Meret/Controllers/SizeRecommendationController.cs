using Dancers.Dnn.Dnn_DancersChoice_Meret.Services;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dancers.Dnn.Dnn_DancersChoice_Meret.Controllers
{
    public class SizeRecommendationController : DnnController
    {
        private readonly SizeRecommendationService _service;

        public SizeRecommendationController()
        {
            _service = new SizeRecommendationService();
        }

        public ActionResult Index()
        {
            var recommendations = _service.GetAllRecommendations();
            return View(recommendations);
        }
    }
}
