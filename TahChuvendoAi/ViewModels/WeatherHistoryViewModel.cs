using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahChuvendoAi.ViewModels
{
    public class WeatherHistoryViewModel
    {
        public string IntroTitle { get; set; }
        public string IntroImage { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public int Probabilidade { get; set; }
        public bool VaiChuver { get; set; }
        public string Discriminicao { get; set; }
        public string Image { get; set; }
    }
}
