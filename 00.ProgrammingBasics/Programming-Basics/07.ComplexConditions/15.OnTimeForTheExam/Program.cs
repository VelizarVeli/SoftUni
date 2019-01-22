using System;

namespace _15.OnTimeForTheExam
{
    class Program
    {
        static void Main()
        {
            int examHour = int.Parse(Console.ReadLine());
            int examinutes = int.Parse(Console.ReadLine());
            int arriveHour = int.Parse(Console.ReadLine());
            int arriveMinutes = int.Parse(Console.ReadLine());

            int inMinExam = examHour * 60 + examinutes;
            int inMinArrive = arriveHour * 60 + arriveMinutes;

            int diffInMinutes = Math.Abs(inMinExam - inMinArrive);
            int diffHours = diffInMinutes / 60;
            int diffMinutes = diffInMinutes % 60;

            if (inMinExam < inMinArrive)
            {
                Console.Write("Late");
            }
            else if (inMinExam >= inMinArrive && inMinExam <= (inMinArrive + 30))
            {
                Console.Write("On time");
            }
            else
                Console.Write("Early");
            if (inMinExam < inMinArrive)
            {
                if (diffInMinutes < 60)
                {
                    Console.WriteLine($" {diffInMinutes} minutes after the start");
                }
                else if (diffInMinutes >= 60)
                {
                    if (diffMinutes > 9)
                    {
                        Console.WriteLine($" {diffHours}:{diffMinutes} hours after the start");
                    }
                    else
                        Console.WriteLine($" {diffHours}:0{diffMinutes} hours after the start");
                }
            }
            else if (inMinExam > inMinArrive)
            {
                if (diffInMinutes < 60)
                {
                    Console.WriteLine($" {diffInMinutes} minutes before the start");
                }
                else if (diffInMinutes >= 60)
                {
                    if (diffMinutes > 9)
                    {
                        Console.WriteLine($" {diffHours}:{diffMinutes} hours before the start");
                    }
                    else
                        Console.WriteLine($" {diffHours}:0{diffMinutes} hours before the start");
                }
            }
        }
    }
}
