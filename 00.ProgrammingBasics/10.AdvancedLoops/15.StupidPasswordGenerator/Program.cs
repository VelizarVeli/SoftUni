using System;

namespace _15.StupidPasswordGenerator
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            
            for (int i1 = 1; i1 <= n; i1++)
            {
                for (int i2 = i1 + 1; i2 <= l; i2++)
                {
                    for (int i3 = i2 + 1; i3 <= 46; i3++)
                    {
                        for (int i5 = i3 + 1; i5 <= 48; i5++)
                        {
                            for (int i6 = i5 + 1; i6 <= 49; i6++)
                            {
                                Console.WriteLine(i1 + "" + i2 + "" +
                                         i3 + "" + i5 + "" + i6);
                            }
                        }
                    }
                }
            }
        }
    }
}
