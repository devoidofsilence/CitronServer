using CitronAppCore.DomainManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;
using CitronInfrastructure.PersistenceManagers;
using CitronInfrastructure.Exceptions;

namespace CitronInfrastructure
{

    public class EmployeeManager : IEmployeeManager
    {
        IEmployeePersistenceManager _employeePersistenceManager;
        IEmployeeJobDetailPersistenceManager _employeeJobDetailPersistenceManager;
        IEmployeeAccountDetailPersistenceManager _employeeAccountDetailPersistenceManager;
        IEmployeeSalaryHistoryPersistenceManager _employeeSalaryHistoryPersistenceManager;
        IEmployeeJobHistoryPersistenceManager _employeeJobHistoryPersistenceManager;
        IEmployeeAllowanceDetailPersistenceManager _employeeAllowanceDetailPersistenceManager;
        IEmployeeJobDepartmentDetailPersistenceManager _employeeJobDepartmentDetailPersistenceManager;
        ILeavePersistenceManager _leavePersistenceManager;


        public EmployeeManager(IEmployeePersistenceManager employeePersistenceManager, IEmployeeJobDetailPersistenceManager employeeJobDetailPersistenceManager, IEmployeeAccountDetailPersistenceManager employeeAccountDetailPersistenceManager, IEmployeeSalaryHistoryPersistenceManager employeeSalaryHistoryPersistenceManager, IEmployeeJobHistoryPersistenceManager employeeJobHistoryPersistenceManager, IEmployeeAllowanceDetailPersistenceManager employeeAllowanceDetailPersistenceManager, IEmployeeJobDepartmentDetailPersistenceManager employeeJobDepartmentDetailPersistenceManager, ILeavePersistenceManager leavePersistenceManager)
        {
            _employeePersistenceManager = employeePersistenceManager;
            _employeeJobDetailPersistenceManager = employeeJobDetailPersistenceManager;
            _employeeAccountDetailPersistenceManager = employeeAccountDetailPersistenceManager;
            _employeeJobHistoryPersistenceManager = employeeJobHistoryPersistenceManager;
            _employeeSalaryHistoryPersistenceManager = employeeSalaryHistoryPersistenceManager;
            _employeeAllowanceDetailPersistenceManager = employeeAllowanceDetailPersistenceManager;
            _employeeJobDepartmentDetailPersistenceManager = employeeJobDepartmentDetailPersistenceManager;
            _leavePersistenceManager = leavePersistenceManager;
        }

        public Employee RecruitEmployee(Employee employee)
        {
            var foundEmployee = _employeePersistenceManager.Find(employee.Code);
            if (string.IsNullOrEmpty(foundEmployee.Code))
            {
                _employeePersistenceManager.Create(employee);
            }
            else
            {
                throw new EmployeeAlreadyExistsException(employee);
            }
            return employee;
        }

        public Employee UpdateEmployeeDetail(Employee employee)
        {
            var foundEmployee = _employeePersistenceManager.Find(employee.Code);
            if (!string.IsNullOrEmpty(foundEmployee.Code))
            {
                _employeePersistenceManager.Update(employee);
            }
            else
            {
                throw new EmployeeNotFoundException(employee);
            }
            return employee;
        }

        public Employee DeleteEmployeeDetail(Employee employee)
        {
            _employeePersistenceManager.Delete(employee);
            return employee;
        }

        public Employee AddEmployeeJobDetail(Employee employee)
        {
            _employeeJobDetailPersistenceManager.Create(employee);
            _employeeJobDepartmentDetailPersistenceManager.Create(employee);

            return employee;
        }

        public Employee UpdateEmployeeJobDetail(Employee employee)
        {
            _employeeJobDetailPersistenceManager.Update(employee);
            _employeeJobDepartmentDetailPersistenceManager.Create(employee);

            return employee;
        }

        public Employee DeleteEmployeeJobDetail(Employee employee)
        {
            _employeeJobDetailPersistenceManager.Delete(employee);

            return employee;
        }

        public Employee AddEmployeeAccountDetail(Employee employee)
        {
            _employeeAccountDetailPersistenceManager.Create(employee);
            _employeeAllowanceDetailPersistenceManager.Create(employee);

            return employee;
        }

        public Employee UpdateEmployeeAccountDetail(Employee employee)
        {
            _employeeAccountDetailPersistenceManager.Update(employee);
            _employeeAllowanceDetailPersistenceManager.Create(employee);

            return employee;
        }

        public Employee DeleteEmployeeAccountDetail(Employee employee)
        {
            _employeeAccountDetailPersistenceManager.Delete(employee);

            return employee;
        }

        public Employee PromoteEmployee(Employee employee)
        {
            _employeeJobDetailPersistenceManager.Update(employee);
            _employeeJobHistoryPersistenceManager.Create(employee);
            return employee;
        }

        public Employee ReviewEmployeeSalary(Employee employee)
        {
            _employeeAccountDetailPersistenceManager.Update(employee);
            _employeeSalaryHistoryPersistenceManager.Create(employee);
            return employee;
        }

        public IList<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(string employeeTagNo)
        {
            throw new NotImplementedException();
        }

        public bool IsEmployeeAbsent(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool IsEmployeeOnLeave(Employee employee, DateTime onWhichDay)
        {
            throw new NotImplementedException();
        }

        public Employee MarkAsAbsent(Employee employee, DateTime onWhichDay)
        {
            // check if employee exists by fetching employee from database
            var dbEmployee = _employeePersistenceManager.Find(employee.Code);

            throw new EmployeeNotFoundException(employee);


            if (dbEmployee != null)
            {
                _leavePersistenceManager.Create(null);
            }
            return employee;
        }

        public IList<Employee> GetAllEmployeeFromGivenDepartment(string departmentCode)
        {
            throw new NotImplementedException();
        }
    }
}
