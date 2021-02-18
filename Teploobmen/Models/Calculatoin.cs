using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Teploobmen.DTO.StaticRatio;

namespace Teploobmen.Models
{
    public class Calculatoin
    {
        public int w { get; set; }
        public int tB { get; set; }
        public double d { get; set; }

        private List<int> tList = new List<int>() { 0, 50, 100, 150, 200, 250, 300, 350, 400, 450, 500, 550, 600, 650, 700, 750, 800, 850, 900, 950, 1000 };
        private List<double> vList = new List<double>() { 13.3, 18.2, 23.1, 28.95, 34.8, 24.45, 32.6, 48.9, 63, 39.95, 53.3, 79.9, 96.8, 57.9, 71, 124.05, 134.8, 144.95, 155.1, 166.1, 177.1 };
        private List<double> lList = new List<double>() { 2.44, 2.82, 3.21, 3.57, 3.93, 2.285, 3.05, 4.57, 5.21, 2.8575, 3.81, 5.715, 6.22, 3.35, 3.66, 5.865, 7.18, 7.405, 7.63, 7.85, 8.07 };
        private List<double> prList = new List<double>() { 0.71, 0.7, 0.69, 0.68, 0.68, 0.34, 0.45, 0.68, 0.68, 0.345, 0.46, 0.69, 0.7, 0.3525, 0.3575, 0.53875, 0.71, 0.715, 0.72, 0.72, 0.72 };

        public string vlpStr()
        {
            int index = tList.IndexOf(tB);
            return $"٧={vList[index]} м2/с; λ={lList[index]} Вт/(м*К); Pr={prList[index]}";
        }
        public double CalcRe()
        {
            return Math.Round(w * d / (vList[tList.IndexOf(tB)] * Math.Pow(10, -6)));
        }
        public double CalcNu()
        {
            return Math.Round(0.21 * Math.Pow(CalcRe(), 0.65), 1);
        }
        public double CalcA3()
        {
            return d == 0 ? 0 : Math.Round(CalcNu() * lList[tList.IndexOf(tB)] * Math.Pow(10, -2) / d, 1);
        }
        public double CalcNuw()
        {
            return Math.Round(0.37 * Math.Pow(CalcRe(), 0.6), 1);
        }
        public double CalcA3w()
        {   double k = d == 0 ? 0 : Math.Round(CalcNuw() * lList[tList.IndexOf(tB)] * Math.Pow(10, -2) / d, 1);
           SetRatio(k);
            return k;
        }
    }
}
