using System;

namespace _08.SMSTyping
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int offset = 0;
            string word = "";
            int index = 0;

            for (int i = 1; i <= n; i++)
            {
                int TMC = int.Parse(Console.ReadLine());
                int digitLength = (int)Math.Floor(Math.Log10(TMC) + 1);
                int mainDigit = Math.Abs(TMC % 10);
                if (mainDigit == 0)
                {
                    index = -65;
                }
                else
                {

                    if (mainDigit == 8 || mainDigit == 9)
                    {
                        offset = ((mainDigit - 2) * 3) + 1;
                    }
                    else
                    {
                        offset = (mainDigit - 2) * 3;
                    }
                    index = (offset + digitLength - 1);
                }
                word = word + (char)(index + 97);
            }
            Console.WriteLine(word);
        }
    }
}
