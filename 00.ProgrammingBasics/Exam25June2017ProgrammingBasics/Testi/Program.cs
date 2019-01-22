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

            double moneyTortiPerDayPerSladkar = tortiPerDay * 45;
            double moneyGofretiPerDayPerSladkar = gofretiPerDay * 5.8;
            double moneyPalachinkiPerDayPerSladkar = palachinkiDay * 3.2;
            double totalSumPerDay = (moneyTortiPerDayPerSladkar + moneyGofretiPerDayPerSladkar + moneyPalachinkiPerDayPerSladkar) * sladkari;

            double sumForTheWholeCampaign = totalSumPerDay * days;
            double SumAfterRazhodi = sumForTheWholeCampaign - (sumForTheWholeCampaign / 8);

            Console.WriteLine($"{SumAfterRazhodi:f2}");
        }
    }
}
