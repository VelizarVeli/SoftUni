using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
           var progressInfo = new File("file", 100, 1024);
           var progressInfo2 = new Music("file","Vetrove", 100, 1024);
        }
    }
}
