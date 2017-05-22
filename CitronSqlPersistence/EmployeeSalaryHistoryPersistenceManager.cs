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
    public class EmployeeSalaryHistoryPersistenceManager : IEmployeeSalaryHistoryPersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public Employee Create(Employee employee)
        {
            var employeeSelected = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            var employeeSelectedinAccountDetail = db.EmployeeAccountDetailPersistenceEntities.FirstOrDefault(e => e.EmployeeID == employeeSelected.ID);
            var employeeSalaryHistoryPersistenceEntity = new EmployeeSalaryHistoryPersistenceEntity();
            employeeSalaryHistoryPersistenceEntity.EmployeeID = employeeSelected.ID;
            employeeSalaryHistoryPersistenceEntity.SalaryWithTax = employeeSelectedinAccountDetail.SalaryWithTax;
            employeeSalaryHistoryPersistenceEntity.From = new DateTime();
            employeeSalaryHistoryPersistenceEntity.To = DateTime.Now;
            db.EmployeeSalaryHistoryPersistenceEntities.Add(employeeSalaryHistoryPersistenceEntity);

            db.SaveChanges();
            return employee;
        }

        public Employee Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee Delete(Employee employee)
        {
            throw new NotImplementedException();
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
