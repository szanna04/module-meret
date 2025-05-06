using Dancers.Dnn.Dnn_DancersChoice_Meret.Models;
using DotNetNuke.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dancers.Dnn.Dnn_DancersChoice_Meret.Services
{
    public class SizeRecommendationService
    {
        public SizeRecommendation GetRecommendedSize(int bust, int waist, int hip)
        {
            using (var ctx = DataContext.Instance())
            {
                return ctx.GetRepository<SizeRecommendation>()
                    .Find("WHERE @0 BETWEEN MinBust AND MaxBust AND @1 BETWEEN MinWaist AND MaxWaist AND @2 BETWEEN MinHip AND MaxHip",
                          bust, waist, hip)
                    .FirstOrDefault();
            }
        }

        public List<SizeRecommendation> GetAllRecommendations()
        {
            using (var ctx = DataContext.Instance())
            {
                var repo = ctx.GetRepository<SizeRecommendation>();
                return repo.Get().ToList();
            }
        }
    }
}
