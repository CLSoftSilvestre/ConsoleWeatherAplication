using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPC_Menu_Consola
{
    class Coordinates
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    class WeatherDef
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    class Wind
    {
        public float speed { get; set; }
        public int deg { get; set; }
    }

    class Clouds
    {
        public int all { get; set; }
    }

    class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public double sunrise { get; set; }
        public double sunset { get; set; }
    }

    class Weather
    {
        public Coordinates coord { get; set; }
        public WeatherDef[] weather { get; set; }
        public string base1 {get; set;}
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public double dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public double id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }

    }
}
