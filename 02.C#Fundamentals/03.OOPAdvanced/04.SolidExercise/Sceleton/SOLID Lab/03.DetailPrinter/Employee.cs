using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Employee
    {
        private string name;

        public Employee(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return $"Name: {this.name}";
        }
    }
}
