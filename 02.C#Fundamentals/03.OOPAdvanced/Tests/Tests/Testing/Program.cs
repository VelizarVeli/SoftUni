using System;
using System.Collections.Generic;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            int counter = 0;
            List<string> list = new List<string>();
            NewMethod(n, ref counter, list);
            if (counter == 0)
            {
                Console.WriteLine($"{n} can't fit in any type");
            }
            else
            {
                Console.WriteLine($"{n} can fit in:");
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    Console.WriteLine(list[i]);
                }
            }

        }

        private static void NewMethod(string n, ref int counter, List<string> list)
        {
            try
            {
                long.Parse(n);
            }
            catch (Exception)
            {

                return;
            }
            list.Add("* long");
            counter++;
            if (!n.Contains("-"))
            {
                try
                {
                    uint.Parse(n);
                }
                catch (Exception)
                {

                    return;
                }
                list.Add("* uint");
                counter++;
            }
            try
            {
                int.Parse(n);
            }
            catch (Exception)
            {

                return;
            }
            list.Add("* int");
            counter++;
            if (!n.Contains("-"))
            {
                try
                {
                    ushort.Parse(n);
                }
                catch (Exception)
                {

                    return;
                }
                list.Add("* ushort");
                counter++;
            }
            try
            {
                short.Parse(n);
            }
            catch (Exception)
            {

                return;
            }
            list.Add("* short");
            counter++;
            try
            {
                byte.Parse(n);
            }
            catch (Exception)
            {

                return;
            }
            list.Add("* byte");
            counter++;
            try
            {
                sbyte.Parse(n);
            }
            catch (Exception)
            {

                return;
            }
            list.Add("* sbyte");
            counter++;
        }

    }
}