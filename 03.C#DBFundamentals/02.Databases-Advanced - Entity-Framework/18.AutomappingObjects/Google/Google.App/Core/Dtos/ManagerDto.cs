using System.Collections.Generic;

namespace Google.App.Core.Dtos
{
   public class ManagerDto
    {
        public ManagerDto()
        {
            this.EmployeeDtos = new HashSet<EmployeeDto>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int EmployeesCount => EmployeeDtos.Count;

        public ICollection<EmployeeDto> EmployeeDtos { get; set; }
    }
}
