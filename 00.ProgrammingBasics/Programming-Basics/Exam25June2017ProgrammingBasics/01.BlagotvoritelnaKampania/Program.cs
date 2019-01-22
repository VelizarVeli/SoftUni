using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BlagotvoritelnaKampania
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int sladkari = int.Parse(Console.ReadLine());
            int tortiPerDay = int.Parse(Console.ReadLine());
            int gofretiPerDay = int.Parse(Console.ReadLine());
            int palachinkiDay = int.Parse(Console.ReadLine());

            int torti = tortiPerDay * days * sladkari;
            int gofreti = gofretiPerDay * days * sladkari;
            int palachinki = palachinkiDay * days * sladkari;

            double money = ((torti * 45) + (gofreti * 5.8) + (palachinki * 3.2)) / 8;
            double total = money * 7;
            Console.WriteLine($"{total:f2}");
        }
    }
}
