using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Teploobmen.DTO.StaticRatio;

namespace Teploobmen.Models
{
    public class ChartData
    {
        public List<string> temperature { get; set; }
        public List<double> coefficient { get; set; }
        
        public ChartData()
        {
            double a = GetRatio();
            temperature = new List<string> { "90°", "80°", "70°", "60°", "50°", "40°", "30°", "20°", "10°"};
            List<double> eList = new List<double> { 1, 1, 0.98, 0.94, 0.88, 0.78, 0.67, 0.52, 0.42 };
            coefficient = eList.Select(x => Math.Round(x * a,1)).ToList();
        }
        public string SerealizeData()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
