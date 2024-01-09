using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TahChuvendoAi.Models
{
    public class WeatherHistory
    {
        public string IntroTitle { get; set; }
        public string WeatherImage { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public int Probabilidade { get; set; }
        public bool VaiChuver { get; set; }
        public string Discriminicao { get; set; }
        public string Image { get; set; }
    }
}
