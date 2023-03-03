using System;
using ComposedWeaponPlanning;
using ConsoleTables;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        int width = (int)MathF.Floor(Console.WindowWidth * 0.75f);

        TextProgressBar progress = new TextProgressBar(width, '(', ')', '=', ' ');
        progress.ShowPercent = true;

        for (int i = 0; i < 100; i++) {
            double frac = (double)i / 100.0;

            progress.SetProgrees((float)frac);

            System.Threading.Thread.Sleep(10);

            ClearLine();
            Console.WriteLine(progress.Render());
        }


        Console.WriteLine(AsciiWeapons.Pistol);
    }

    static void ClearLine()
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, Console.CursorTop - 1);
    }
}