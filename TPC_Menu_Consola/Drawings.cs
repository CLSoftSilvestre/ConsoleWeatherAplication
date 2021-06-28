using System;
namespace TPC_Menu_Consola
{
    public class Drawings
    {

        public static void drawSun(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            printPosition(x, y,   "    \\   /");
            printPosition(x, y+1, "     .-.");
            printPosition(x, y+2, " -- (   ) --");
            printPosition(x, y+3, "     `-´ ");
            printPosition(x, y+4, "    /    \\");
        }

        public static void drawSunClouds(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            printPosition(x, y, "   \\  /");
            printPosition(x, y+1, " _`/**");
            Console.ForegroundColor = ConsoleColor.White;
            printPosition(x+6, y+1, ".-.");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            printPosition(x, y+2, "  ,\\_");
            Console.ForegroundColor = ConsoleColor.White;
            printPosition(x+5, y+2, "(   ).");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            printPosition(x, y+3, "   /");
            Console.ForegroundColor = ConsoleColor.White;
            printPosition(x+4, y+3, "(___(__)");
        }

        public static void drawClouds(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.White;
            printPosition(x+1, y+1, "    .-.");
            printPosition(x+1, y+2, "   (   ).");
            printPosition(x+1, y+3, "  (___(__)");
        }

        public static void drawDarkClouds(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            printPosition(x+1, y+1, "    .-.");
            printPosition(x+1, y+2, "   (   ).");
            printPosition(x+1, y+3, "  (___(__)");
        }

        public static void drawCloudsRain(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            printPosition(x+1, y, "    .-.");
            printPosition(x+1, y+1, "   (   ).");
            printPosition(x+1, y+2, "  (___(__)");
            Console.ForegroundColor = ConsoleColor.Blue;
            printPosition(x+1, y+3, "   / / / /");
            printPosition(x+1, y+4, "  / / / /");
        }

        public static void drawSunCloudsRain(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            //Console.BackgroundColor = ConsoleColor.DarkBlue; X=14
            printPosition(x, y, "   \\  /");
            printPosition(x, y+1, " _`/**");
            Console.ForegroundColor = ConsoleColor.White;
            printPosition(x+6, y+1, ".-.");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            printPosition(x, y+2, "  ,\\_");
            Console.ForegroundColor = ConsoleColor.White;
            printPosition(x+5, y+2, "(   ).");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            printPosition(x, y+3, "   /");
            Console.ForegroundColor = ConsoleColor.White;
            printPosition(x+4, y+3, "(___(__)");
            Console.ForegroundColor = ConsoleColor.Blue;
            printPosition(x+4, y+4, " ´ ´ ´ ´");
            printPosition(x+4, y+5, "´ ´ ´ ´");
        }

        public static void drawLightning(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            printPosition(x+1, y, "    .-.");
            printPosition(x+1, y+1, "   (   ).");
            printPosition(x+1, y+2, "  (___(__)");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            printPosition(x+1, y+3, "     \\ \\");
            printPosition(x+1, y+4, "      /");
        }

        public static void drawSnow(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            printPosition(x+1, y, "    .-.");
            printPosition(x+1, y+1, "   (   ).");
            printPosition(x+1, y+2, "  (___(__)");
            Console.ForegroundColor = ConsoleColor.White;
            printPosition(x+1, y+3, "   * * * *");
            printPosition(x+1, y+4, "  * * * *");
        }

        public static void drawFog(int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            printPosition(x+1, y, "    .-.");
            printPosition(x+1, y+1, "   (   ).");
            printPosition(x+1, y+2, "  (___(__)");
            Console.ForegroundColor = ConsoleColor.White;
            printPosition(x+1, y+3, "   ~ ~ ~ ~ ");
            printPosition(x+1, y+4, "    ~ ~ ~ ~");
        }

        private static void printPosition(int x, int y, string text)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
    }
}
