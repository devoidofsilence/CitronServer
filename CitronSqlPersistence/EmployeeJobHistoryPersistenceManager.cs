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
    public class EmployeeJobHistoryPersistenceManager : IEmployeeJobHistoryPersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public Employee Create(Employee employee)
        {
            var employeeSelected = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            var employeeSelectedinJobDetail = db.EmployeeJobDetailPersistenceEntities.FirstOrDefault(e => e.EmployeeID == employeeSelected.ID);
            foreach (var item in employee.JobDepartments)
            {
                var employeeJobHistoryPersistenceEntity = new EmployeeJobHistoryPersistenceEntity();
                employeeJobHistoryPersistenceEntity.EmployeeID = employeeSelected.ID;
                employeeJobHistoryPersistenceEntity.DesignationID = employeeSelectedinJobDetail.DesignationID;
                employeeJobHistoryPersistenceEntity.Description = employee.JobDescription;
                employeeJobHistoryPersistenceEntity.DepartmentID = item;
                employeeJobHistoryPersistenceEntity.AssignedFrom = new DateTime();
                employeeJobHistoryPersistenceEntity.AssignedTo = DateTime.Now;
                db.EmployeeJobHistoryPersistenceEntities.Add(employeeJobHistoryPersistenceEntity);
            }

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
