using System;
using System.Text.Json;
using System.Text;
using System.Net;
using System.IO;


namespace TPC_Menu_Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleScreen cs = new ConsoleScreen();

            int opcao = -1;

            while(opcao != 0)
            {
                cs.printMenu();
                Console.SetCursorPosition(63, 16);
                Console.CursorVisible = true;
                try
                {
                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            // Ponta Delgada
                            string urlPdl = "http://api.openweathermap.org/data/2.5/weather?id=3372783&appid=439f2c0ec9007cfd5e0a299dc5e243b0&units=metric&lang=pt";
                            ShowCityWeather(urlPdl, cs);
                            break;
                        case 2:
                            // Lisboa
                            string urlLis = "http://api.openweathermap.org/data/2.5/weather?id=2267057&appid=439f2c0ec9007cfd5e0a299dc5e243b0&units=metric&lang=pt";
                            ShowCityWeather(urlLis, cs);
                            break;
                        case 3:
                            // Porto
                            string urlOpo = "http://api.openweathermap.org/data/2.5/weather?id=2735943&appid=439f2c0ec9007cfd5e0a299dc5e243b0&units=metric&lang=pt";
                            ShowCityWeather(urlOpo, cs);
                            break;
                        case 4:
                            // Faro
                            string urlAlg = "http://api.openweathermap.org/data/2.5/weather?id=2268339&appid=439f2c0ec9007cfd5e0a299dc5e243b0&units=metric&lang=pt";
                            ShowCityWeather(urlAlg, cs);
                            break;
                        case 0:
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Favor inserir um valor válido...");
                }

            }

        }

        public static void ShowCityWeather(string url, ConsoleScreen cs)
        {
            string jsonString;

            jsonString = CallRestMethod(url);

            Weather weather = JsonSerializer.Deserialize<Weather>(jsonString);

            cs.drawWeatherInfo(weather);
            Console.ReadKey();

        }

        public static string CallRestMethod(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream());
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();
            return result;
        }

        public static double ConversionCtoF(double celsius)
        {
            return celsius * 1.8 + 32;
        }
    }

}

