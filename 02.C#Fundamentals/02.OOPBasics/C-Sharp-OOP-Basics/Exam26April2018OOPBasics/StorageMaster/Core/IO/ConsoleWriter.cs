﻿using System;
using StorageMaster.Core.IO.Contracts;

namespace StorageMaster.Core.IO
{
  public  class ConsoleWriter:IWriter
    {
        public void WriteLine(string message)
        {
			Console.WriteLine(message);
        }
    }
}
