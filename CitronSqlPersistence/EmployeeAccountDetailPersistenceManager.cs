using CitronInfrastructure.PersistenceManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;
using CitronSqlPersistence.PersistenceEntities;

namespace CitronSqlPersistence
{
    public class EmployeeAccountDetailPersistenceManager : IEmployeeAccountDetailPersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public Employee Create(Employee employee)
        {
            var employeeSelected = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            var employeeAccountDetailPersistenceEntity = new EmployeeAccountDetailPersistenceEntity()
            {
                EmployeeID = employeeSelected.ID,
                BankName = employee.BankName,
                BankBranch = employee.BankBranch,
                BankAccountNo = employee.BankAccountNo,
                SalaryWithTax = employee.SalaryWithTax
            };

            db.EmployeeAccountDetailPersistenceEntities.Add(employeeAccountDetailPersistenceEntity);
            db.SaveChanges();
            return employee;
        }

        public Employee Update(Employee employee)
        {
            var employeeSelected = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            var employeeAccountDetailPersistenceEntity = db.EmployeeAccountDetailPersistenceEntities.FirstOrDefault(e => e.EmployeeID == employeeSelected.ID);
            employeeAccountDetailPersistenceEntity.BankName = employee.BankName;
            employeeAccountDetailPersistenceEntity.BankBranch = employee.BankBranch;
            employeeAccountDetailPersistenceEntity.BankAccountNo = employee.BankAccountNo;
            //employeeAccountDetailPersistenceEntity.SalaryWithTax = employee.SalaryWithTax; => For ReviewofSalary only

            db.SaveChanges();
            return employee;
        }

        public Employee Delete(Employee employee)
        {
            var employeeSelected = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            var employeeAccountDetailPersistenceEntity = db.EmployeeAccountDetailPersistenceEntities.FirstOrDefault(e => e.EmployeeID == employeeSelected.ID);
            db.EmployeeAccountDetailPersistenceEntities.Remove(employeeAccountDetailPersistenceEntity);

            db.SaveChanges();
            return employee;
        }

        public Employee Find(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> FindAll(Func<Employee, bool> condition)
        {
            throw new NotImplementedException();
        }

        public Employee Read(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
