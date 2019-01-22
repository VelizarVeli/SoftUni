using System;

namespace Test1
{
    public class Worker : IWorker
    {
        public string Name { get; }

        public Worker(string name)
        {
            this.Name = name;
        }

        public void Work()
        {
            Console.WriteLine($"{Name} is a very hard worker");
        }
    }
}
