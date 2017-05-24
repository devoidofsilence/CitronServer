using CitronAppCore.DomainEntities;
using System;
using System.Collections.Generic;

namespace CitronAppCore.DomainManagers
{
    public interface IEmployeeManager
    {
        Employee RecruitEmployee(Employee employee);
        Employee UpdateEmployeeDetail(Employee employee);
        Employee DeleteEmployeeDetail(Employee employee);
        Employee AddEmployeeJobDetail(Employee employee);
        Employee UpdateEmployeeJobDetail(Employee employee);
        Employee DeleteEmployeeJobDetail(Employee employee);
        Employee AddEmployeeAccountDetail(Employee employee);
        Employee UpdateEmployeeAccountDetail(Employee employee);
        Employee DeleteEmployeeAccountDetail(Employee employee);
        Employee PromoteEmployee(Employee employee);
        Employee ReviewEmployeeSalary(Employee employee);
        Employee MarkAsAbsent(Employee employee, DateTime onWhichDay);
        bool IsEmployeeAbsent(Employee employee);
        bool IsEmployeeOnLeave(Employee employee, DateTime onWhichDay);
        IList<Employee> GetEmployees(Func<Employee, bool> condition);
    }
}
