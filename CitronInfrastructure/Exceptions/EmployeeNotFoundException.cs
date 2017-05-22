using CitronAppCore.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronInfrastructure.Exceptions
{
    public class EmployeeNotFoundException: Exception
    {
        Employee _employee;
        public EmployeeNotFoundException(Employee employee): base("Employee Not Found")
        {
            _employee = employee;
        }

        public override string Message => $"Employee with employee code {_employee.Code} not found";
    }
}
