using System;

namespace _05.BPMCounter
{
    class Program
    {
        static void Main()
        {
            double bpm = double.Parse(Console.ReadLine());
            double numberOfBeats = int.Parse(Console.ReadLine());

            double bps = bpm / 60;
            double time = numberOfBeats / bps;
            double minutes = Math.Truncate(time / 60);
            double seconds = Math.Truncate(time % 60);
            
            Console.WriteLine($"{Math.Round(numberOfBeats / 4,1)} bars - {minutes}m {seconds}s");
        }
    }
}
