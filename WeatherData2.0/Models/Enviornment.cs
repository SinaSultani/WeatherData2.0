using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherData2._0.Models
{
    public class Enviornment
    {
        
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Temperature { get; set; }
        public int Humidity { get; set; }
        public string InsideOrOutside { get; set; }

    }
}
