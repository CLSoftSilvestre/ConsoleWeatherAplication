using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPC_Menu_Consola
{
    // Esta classe contem todas as funções necessárias para desenhar componentes no ecra.
    class ConsoleScreen
    {
        public void clearScreen(ConsoleColor bgColor)
        {
            Console.BackgroundColor = bgColor;
            Console.Clear();
        }

        public void setColor(ConsoleColor fgColor, ConsoleColor bgColor)
        {
            Console.BackgroundColor = bgColor;
            Console.ForegroundColor = fgColor;
        }

        public void printPosition(int x, int y, string text)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }

        public void printBox()
        {
            clearScreen(ConsoleColor.DarkBlue);
            setColor(ConsoleColor.White, ConsoleColor.DarkBlue);
            Console.WriteLine("  ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("  ║  ESTADO DO TEMPO NA CONSOLA                                                                                      ║");
            Console.WriteLine("  ╠═══════════════════════════════════════╤══════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("  ║                                       │      ┌───────────┬───────────────────────────────────────────────┐       ║");
            Console.WriteLine("  ║                                       │      │  CIDADE   │                                               │       ║");
            Console.WriteLine("  ║                                       │      └───────────┴───────────────────────────────────────────────┘       ║");
            Console.WriteLine("  ║                                       │                                                                          ║");
            Console.WriteLine("  ║                                       │      ┌───────────┬───────────────────────────────────────────────┐       ║");
            Console.WriteLine("  ║                                       │      │ LATITUDE  │                                               │       ║");
            Console.WriteLine("  ║                                       │      └───────────┴───────────────────────────────────────────────┘       ║");
            Console.WriteLine("  ║                                       │                                                                          ║");
            Console.WriteLine("  ║                                       │      ┌───────────┬───────────────────────────────────────────────┐       ║");
            Console.WriteLine("  ║                                       │      │ LONGITUDE │                                               │       ║");
            Console.WriteLine("  ║                                       │      └───────────┴───────────────────────────────────────────────┘       ║");
            Console.WriteLine("  ╟───────────────────────────────────────┤                                                                          ║");
            Console.WriteLine("  ║                                       │                                                                          ║");
            Console.WriteLine("  ╟───────────────────────────────────────┘                                                                          ║");
            Console.WriteLine("  ║ ┌───────────┬──────────────────┬────┐ ┌───────────┬───────────────────────┐ ┌───────────┬───────────────────────┐║");
            Console.WriteLine("  ║ │   Temp.   │                  │ ºC │ │  Estado   │                       │ │Data e hora│                       │║");
            Console.WriteLine("  ║ └───────────┴──────────────────┴────┘ └───────────┴───────────────────────┘ └───────────┴───────────────────────┘║");
            Console.WriteLine("  ║ ┌───────────┬──────────────────┬────┐ ┌───────────┬──────────────────┬────┐ ┌───────────┬───────────────────────┐║");
            Console.WriteLine("  ║ │   Hum.    │                  │ %  │ │   Vento   │                  │ m/s│ │Nascer sol │                       │║");
            Console.WriteLine("  ║ └───────────┴──────────────────┴────┘ └───────────┴──────────────────┴────┘ └───────────┴───────────────────────┘║");
            Console.WriteLine("  ║ ┌───────────┬──────────────────┬────┐ ┌───────────┬──────────────────┬────┐ ┌───────────┬───────────────────────┐║");
            Console.WriteLine("  ║ │  Pressão  │                  │hPa │ │ Dir.Vento │                  │deg.│ │Por do sol │                       │║");
            Console.WriteLine("  ║ └───────────┴──────────────────┴────┘ └───────────┴──────────────────┴────┘ └───────────┴───────────────────────┘║");
            Console.WriteLine("  ║                                                                        ┌───────────────────────────────────┐     ║");
            Console.WriteLine("  ╚════════════════════════════════════════════════════════════════════════╡    (C) 2021 - Celso Silvestre     ╞═════╝");
            Console.WriteLine("                                                                           └───────────────────────────────────┘      ");

        }

        public void drawWeatherInfo( Weather weather)
        {
            printBox();

            //Cidade
            printPosition(65, 4, weather.name);

            // Latitude
            printPosition(65, 8, weather.coord.lat.ToString());

            //Longitude
            printPosition(65, 12, weather.coord.lon.ToString());

            //Descricao tempo
            printPosition(5, 15, weather.weather[0].main);

            //Temperatura
            printPosition(20, 18, weather.main.temp.ToString());

            //Humidade
            printPosition(20, 21, weather.main.humidity.ToString());

            //Pressão
            printPosition(20, 24, weather.main.pressure.ToString());

            //Estado
            printPosition(57, 18, weather.weather[0].description);

            //Vento
            printPosition(57, 21, weather.wind.speed.ToString());

            //Direcao Vento
            printPosition(57, 24, weather.wind.deg.ToString());

            //Hora metereologia
            var horaMeteo = (new DateTime(1970, 1, 1)).AddSeconds(weather.dt);
            printPosition(96, 18, horaMeteo.ToString());

            //Nascer do sol
            var horaNascer = (new DateTime(1970, 1, 1)).AddSeconds(weather.sys.sunrise);
            printPosition(96, 21, horaNascer.ToShortTimeString());

            //Por do sol
            var horaPor = (new DateTime(1970, 1, 1)).AddSeconds(weather.sys.sunset);
            printPosition(96, 24, horaPor.ToShortTimeString());

            //Desenhar icone em ASCII
            drawWeatherIcon("02n");
        }

        public void drawWeatherIcon(string icon)
        {
            switch (icon)
            {
                case "01n":
                case "01d":
                    //Ceu limpo
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    printPosition(10, 4, "      ;   :   ;");
                    printPosition(10, 5, "   .   \\_,!,_/   ,");
                    printPosition(10, 6, "    `.,'     `.,'");
                    printPosition(10, 7, "     /         \\" );
                    printPosition(10, 8, "~ -- :         : -- ~");
                    printPosition(10, 9, "     \\         /");
                    printPosition(10, 10, "    ,'`._   _.'`.");
                    printPosition(10, 11, "   '   / `!` \\   `");
                    printPosition(10, 12, "      ;   :   ;");
                    break;
                case "02n":
                case "02d":
                    //Poucas nuvens
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    printPosition(8, 4, "      ;   :   ;");
                    printPosition(8, 5, "   .   \\_,!,_/   ,");
                    printPosition(8, 6, "     /         \\");
                    Console.ForegroundColor = ConsoleColor.White;
                    printPosition(8, 7, "    `.,'  .-~~~-.");
                    printPosition(8, 8, "  .- ~ ~-(       )_ _");
                    printPosition(8, 9, " /                     ~ -.");
                    printPosition(8, 10, "|                           \\");
                    printPosition(8, 11, " \\                         .'");
                    printPosition(8, 12, "   ~- . _____________ . -~");
                    break;
              
                case "03n":
                case "03d":
                case "04n":
                case "04d":
                    //Nublado
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    printPosition(8, 5, "          .-~~~-.");
                    printPosition(8, 6, "  .- ~ ~-(       )_ _");
                    printPosition(8, 7, " /                     ~ -.");
                    printPosition(8, 8, "|                           \\");
                    printPosition(8, 9, " \\                         .'");
                    printPosition(8, 10, "   ~- . _____________ . -~");
                    break;
                case "09n":
                case "09d":
                case "10n":
                case "10d":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    printPosition(10, 5, "      __   _");
                    printPosition(10, 6, "    _(  )_( )_ ");
                    printPosition(10, 7, "   (_   _    _)");
                    printPosition(10, 8, "  / /(_) (__)");
                    printPosition(10, 9, " / / / / / /");
                    printPosition(10, 10, "/ / / / / /");
                    break;
                case "11n":
                case "11d":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    printPosition(10, 3, "  (_                       __))");
                    printPosition(10, 4, "    ((                _____)");
                    printPosition(10, 5, "      (_________)----'");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    printPosition(10, 6, "         _/  /");
                    printPosition(10, 7, "        /  _/");
                    printPosition(10, 8, "      _/  /");
                    printPosition(10, 9, "     / __/");
                    printPosition(10, 10, "   _/ /");
                    printPosition(10, 11, "  /__/");
                    printPosition(10, 12, " //");
                    printPosition(10, 13, "/'");
                    break;
                case "13n":
                case "13d":
                    Console.WriteLine("Neve");
                    Console.WriteLine("⛄");
                    break;
                case "50n":
                case "50d":
                    Console.WriteLine("Neblina");
                    Console.WriteLine("");
                    break;
                default:
                    Console.WriteLine("");
                    break;
            }
        }

        public void printMenu()
        {
            clearScreen(ConsoleColor.DarkBlue);
            setColor(ConsoleColor.White, ConsoleColor.DarkBlue);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("  ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("  ║  ESTADO DO TEMPO NA CONSOLA                                                                                      ║");
            Console.WriteLine("  ╠══════════════════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("  ║                                                                                                                  ║");
            Console.WriteLine("  ║                                                                                                                  ║");
            Console.WriteLine("  ║                                                                                                                  ║");
            Console.WriteLine("  ║                                                                                                                  ║");
            Console.WriteLine("  ║                                   ╔════════════════════════════════════════╗                                     ║");
            Console.WriteLine("  ║                                   ║             MENU PRINCIPAL             ║                                     ║");
            Console.WriteLine("  ║                                   ╠════════════════════════════════════════╣                                     ║");
            Console.WriteLine("  ║                                   ║  1 - Estado do tempo em Ponta Delgada  ║                                     ║");
            Console.WriteLine("  ║                                   ║  2 - Estado do tempo em Lisboa         ║                                     ║");
            Console.WriteLine("  ║                                   ║  3 - Estado do tempo no Porto          ║                                     ║");
            Console.WriteLine("  ║                                   ║  0 - Sair da aplicação                 ║                                     ║");
            Console.WriteLine("  ║                                   ║                                        ║                                     ║");
            Console.WriteLine("  ║                                   ║   Insira a sua opção:                  ║                                     ║");
            Console.WriteLine("  ║                                   ║                                        ║                                     ║");
            Console.WriteLine("  ║                                   ║                                        ║                                     ║");
            Console.WriteLine("  ║                                   ╚════════════════════════════════════════╝                                     ║");
            Console.WriteLine("  ║                                                                                                                  ║");
            Console.WriteLine("  ║                                                                                                                  ║");
            Console.WriteLine("  ║                                                                                                                  ║");
            Console.WriteLine("  ║                                                                                                                  ║");
            Console.WriteLine("  ║                                                                                                                  ║");
            Console.WriteLine("  ║                                                                                                                  ║");
            Console.WriteLine("  ║                                                                                                                  ║");
            Console.WriteLine("  ║                                                                        ┌───────────────────────────────────┐     ║");
            Console.WriteLine("  ╚════════════════════════════════════════════════════════════════════════╡    (C) 2021 - Celso Silvestre     ╞═════╝");
            Console.WriteLine("                                                                           └───────────────────────────────────┘      ");

        }

        public void drawRect(int xstart, int ystart, int width, int height, ConsoleColor color)
        {
            for (int x= xstart; x< xstart + width; x++)
            {
                for(int y = ystart; y< ystart + height; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = color;
                    Console.Write("█");
                }
            }

        }
    }
}
