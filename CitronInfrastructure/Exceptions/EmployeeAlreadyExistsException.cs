using CitronAppCore.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronInfrastructure.Exceptions
{
    public class EmployeeAlreadyExistsException : Exception
    {
        Employee _employee;
        public EmployeeAlreadyExistsException(Employee employee): base("Employee Already Exists")
        {
            _employee = employee;
        }

        public override string Message => $"Employee with employee code {_employee.Code} already exists!";
    }
}
