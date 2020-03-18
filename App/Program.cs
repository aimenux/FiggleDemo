using System;
using System.Linq;
using System.Reflection;
using App.Extensions;
using Figgle;

namespace App
{
    public static class Program
    {
        public static void Main()
        {
            var properties = typeof(FiggleFonts)
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.PropertyType == typeof(FiggleFont))
                .ToList();

            var fonts = properties
                .Select(x => x.GetValue(null))
                .OfType<FiggleFont>()
                .ToList();

            const string path = "Figgle.txt";
            const string message = "Hello Figgle";

            foreach (var font in fonts)
            {
                font.WriteLine(message);
                font.WriteLine(path, message);
            }

            ConsoleColor.Yellow.WriteLine("Press any key to exit !");
            Console.ReadKey();
        }
    }
}
