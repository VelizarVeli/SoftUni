using System;

namespace _07.SumSeconds
{
    class Program
    {
        static void Main()
        {
            var num1 = int.Parse(Console.ReadLine());
            var num2 = int.Parse(Console.ReadLine());
            var num3 = int.Parse(Console.ReadLine());
            var resInSeconds = num1 + num2 + num3;

            if (resInSeconds < 60)
            {
                if(resInSeconds < 10)
                {
                Console.WriteLine("0:0{0}", resInSeconds);
                }
                else Console.WriteLine("0:{0}", resInSeconds);
            }
            else if(resInSeconds >= 60 && resInSeconds <= 119)
            {
                if(resInSeconds - 60 < 10)
                {
                    Console.WriteLine("1:0{0}", resInSeconds - 60);
                }
                else Console.WriteLine("1:{0}", resInSeconds - 60);
            }
            else if (resInSeconds >=120 && resInSeconds < 180)
            {
                if(resInSeconds - 120 < 10)
                {
                    Console.WriteLine("2:0{0}", resInSeconds - 120);
                }
                else Console.WriteLine("2:{0}", resInSeconds - 120);
            }
        }
    }
}
