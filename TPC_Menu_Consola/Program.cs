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
                Console.SetCursorPosition(63, 17);
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
                            string urlPdl2 = "http://api.openweathermap.org/data/2.5/forecast?id=3372783&appid=439f2c0ec9007cfd5e0a299dc5e243b0&units=metric&lang=pt";
                            ShowCityWeatherPrediction(urlPdl2, cs);
                            break;
                        case 3:
                            // Lisboa
                            string urlLis = "http://api.openweathermap.org/data/2.5/weather?id=2267057&appid=439f2c0ec9007cfd5e0a299dc5e243b0&units=metric&lang=pt";
                            ShowCityWeather(urlLis, cs);
                            break;
                        case 4:
                            string urlLis2 = "http://api.openweathermap.org/data/2.5/forecast?id=2267057&appid=439f2c0ec9007cfd5e0a299dc5e243b0&units=metric&lang=pt";
                            ShowCityWeatherPrediction(urlLis2, cs);
                            break;
                        case 5:
                            // Porto
                            string urlOpo = "http://api.openweathermap.org/data/2.5/weather?id=2735943&appid=439f2c0ec9007cfd5e0a299dc5e243b0&units=metric&lang=pt";
                            ShowCityWeather(urlOpo, cs);
                            break;
                        case 6:
                            string urlOpo2 = "http://api.openweathermap.org/data/2.5/forecast?id=2735943&appid=439f2c0ec9007cfd5e0a299dc5e243b0&units=metric&lang=pt";
                            ShowCityWeatherPrediction(urlOpo2, cs);
                            break;
                        case 7:
                            // Faro
                            string urlFar = "http://api.openweathermap.org/data/2.5/weather?id=2268339&appid=439f2c0ec9007cfd5e0a299dc5e243b0&units=metric&lang=pt";
                            ShowCityWeather(urlFar, cs);
                            break;
                        case 8:
                            string urlFar2 = "http://api.openweathermap.org/data/2.5/forecast?id=2268339&appid=439f2c0ec9007cfd5e0a299dc5e243b0&units=metric&lang=pt";
                            ShowCityWeatherPrediction(urlFar2, cs);
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

        public static void ShowCityWeatherPrediction(string url, ConsoleScreen cs)
        {
            string jsonString;
            jsonString = CallRestMethod(url);
            WeatherPrediction weatherprediction = JsonSerializer.Deserialize<WeatherPrediction>(jsonString);
            cs.drawWeatherForecast(weatherprediction); //Falta adicionar desenho para previsão...
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

