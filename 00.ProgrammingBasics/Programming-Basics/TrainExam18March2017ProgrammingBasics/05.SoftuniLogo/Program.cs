using System;

namespace _05.SoftuniLogo
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());

            int gorniTochki = (12 * N - 5) / 2;
            int gorniZvezdi = 1;
            int dolniTochki = 2;
            

            for (int i = 0; i < N * 2; i++)
            {
                Console.WriteLine("{0}{1}{0}",new string('.',(gorniTochki)), new string('#', gorniZvezdi));
                gorniTochki -= 3;
                gorniZvezdi += 6;
            }
            for (int i = 0; i < N - 1; i++)
            {
                Console.WriteLine("|{0}{1}{2}", new string('.',dolniTochki), new string('#',gorniZvezdi - 12), new string('.', dolniTochki + 1));
                dolniTochki += 3;
                gorniZvezdi -= 6;
            }
            dolniTochki -= 3;
            gorniZvezdi += 6;
            for (int i = 0; i < N-2; i++)
            {
                Console.WriteLine("|{0}{1}{2}", new string('.', dolniTochki), new string('#', gorniZvezdi - 12), new string('.', dolniTochki + 1));
            }
            Console.WriteLine("@{0}{1}{2}", new string('.', dolniTochki), new string('#', gorniZvezdi - 12), new string('.', dolniTochki + 1));
        }
    }
}
