namespace P03.DetailPrinter
{
    public class Employee
    {
        public Employee(string name)
        {
            this.name = name;
        }

        private string name { get; set; }

        public override string ToString()
        {
            return $"Name: {this.name}";
        }
    }
}
