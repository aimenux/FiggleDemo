using System;
using System.IO;
using Figgle;

namespace App.Extensions
{
    public static class FiggleExtensions
    {
        private static readonly Array Colors = Enum.GetValues(typeof(ConsoleColor));
        private static readonly Random Random = new Random(Guid.NewGuid().GetHashCode());

        public static void WriteLine(this FiggleFont font, string message, bool showErrors = false)
        {
            try
            {
                var color = (ConsoleColor) Colors.GetValue(Random.Next(Colors.Length));
                color.WriteLine(font.Render(message));
            }
            catch (Exception ex)
            {
                if (showErrors)
                {
                    ConsoleColor.Red.WriteLine($"[{ex.GetType().Name}] {ex.Message}");
                }
            }
        }

        public static void WriteLine(this FiggleFont font, string path, string message, bool showErrors = false)
        {
            try
            {
                using var sw = File.AppendText(path);
                sw.WriteLine(font.Render(message));
            }
            catch (Exception ex)
            {
                if (showErrors)
                {
                    ConsoleColor.Red.WriteLine($"[{ex.GetType().Name}] {ex.Message}");
                }
            }
        }
    }
}
