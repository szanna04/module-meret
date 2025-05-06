using DotNetNuke.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dancers.Dnn.Dnn_DancersChoice_Meret.Models
{
    [TableName("SizeRecommendations")]
    [PrimaryKey("ID", AutoIncrement = true)]
    [Scope("ModuleId")]
    public class SizeRecommendation
    {
        public int ID { get; set; }
        public string SizeLabel { get; set; }
        public int MinBust { get; set; }
        public int MaxBust { get; set; }
        public int MinWaist { get; set; }
        public int MaxWaist { get; set; }
        public int MinHip { get; set; }
        public int MaxHip { get; set; }
    }
}
