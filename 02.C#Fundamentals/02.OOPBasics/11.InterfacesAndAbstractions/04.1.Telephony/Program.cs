using System;
using System.Runtime.InteropServices;

namespace _04._1.Telephony
{
    class Program
    {
        static void Main()
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            Calling(phoneNumbers);

            string[] webSites = Console.ReadLine().Split();
            Browsing(webSites);
        }

        private static void Calling(string[] phoneNumbers)
        {
            bool check = true;

            foreach (var number in phoneNumbers)
            {
                char[] isDigit = number.ToCharArray();

                foreach (var digit in isDigit)
                {
                    if (!Char.IsDigit(digit))
                    {
                        Console.WriteLine("Invalid number!");
                        check = false;
                        break;
                    }
                }

                if (check)
                {
                    Smartphone smartphoneCall = new Smartphone();
                    smartphoneCall.Call(number);
                }
            }
        }

        private static void Browsing(string[] webSites)
        {
            foreach (var site in webSites)
            {
                try
                {
                    Smartphone smartphoneBrowse = new Smartphone(site);
                    smartphoneBrowse.Browse();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
