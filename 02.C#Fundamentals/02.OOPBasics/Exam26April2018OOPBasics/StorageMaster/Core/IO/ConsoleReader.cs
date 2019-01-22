using System;
using StorageMaster.Core.IO.Contracts;

namespace StorageMaster.Core.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
