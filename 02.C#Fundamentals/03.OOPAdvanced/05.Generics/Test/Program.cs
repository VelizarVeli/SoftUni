using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use the generic type Test with an int type parameter.
            Test<int> test1 = new Test<int>(5);
            // Call the Write method.
            test1.Write();

            // Use the generic type Test with a string type parameter.
            Test<string> test2 = new Test<string>("cat");
            test2.Write();
        }
    }
}
