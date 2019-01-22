using System;
namespace _05.Parallelepiped
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int tilde = N - 2;
            int l = 1;
            int tochki = N * 2;

            Console.WriteLine("+{0}+{1}", new string('~', tilde), new string('.', N * 2 + 1));
            Console.WriteLine(@"|\{0}\{1}", new string('~', tilde), new string('.', N * 2));

            for (int i = 0; i < 2 * N; i++)
            {
                Console.WriteLine(@"|{0}\{1}\{2}", new string('.', l), new string('~', tilde), new string('.', tochki - 1));
                l++;
                tochki--;
            }

            Console.WriteLine(@"\{0}|{1}|", new string('.', N * 2),new string('~',tilde));
            l = 1;
            tochki = N * 2 - 1;
            for (int i = 0; i < 2 * N - 1; i++)
            {
                Console.WriteLine(@"{0}\{1}|{2}|", new string('.', l), new string('.', tochki), new string('~', tilde));
                l++;
                tochki--;
            }

            Console.WriteLine(@"{1}\|{0}|", new string('~', tilde), new string('.', N * 2));
            Console.WriteLine("{0}+{1}+", new string('.', N * 2 + 1), new string('~', tilde));
        }
    }
}
