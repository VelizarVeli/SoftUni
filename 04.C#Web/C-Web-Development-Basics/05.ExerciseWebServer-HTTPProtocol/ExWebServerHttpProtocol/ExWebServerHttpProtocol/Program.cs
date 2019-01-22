using System;
using System.Net;

namespace _01.URLDecode
{
    public class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(WebUtility.UrlDecode(input));
        }
    }
}
