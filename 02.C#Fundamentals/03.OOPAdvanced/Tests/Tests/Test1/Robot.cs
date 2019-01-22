using System;

namespace Test1
{
    public class Robot : ICheck
    {
        public string Number { get; }

        public Robot(string number)
        {
            this.Number = number;
        }

        public void Work()
        {
            Console.WriteLine($"Robot {Number} works");
        }

        public void Checky()
        {
            Console.WriteLine($"I don't know what I'm doing");
        }

        public override string ToString()
        {
            return $"I don't know what I'm doing";
        }
    }
}
