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

            foreach (var font in fonts)
            {
                font.WriteLine("Hello World!");
            }

            ConsoleColor.Yellow.WriteLine("Press any key to exit !");
            Console.ReadKey();
        }
    }
}
