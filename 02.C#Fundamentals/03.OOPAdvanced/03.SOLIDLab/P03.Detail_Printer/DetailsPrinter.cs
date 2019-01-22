using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private readonly IList<Employee> employees;

        public DetailsPrinter(IList<Employee> employees)
        {
            this.employees = employees;
        }

        public void PrintEmployees(Employee employee)
        {
            foreach (Employee employe in employees)
            {
                Console.WriteLine(employe);
            }
        }
    }
}
