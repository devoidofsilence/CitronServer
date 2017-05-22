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
    public class EmployeeJobDepartmentDetailPersistenceManager : IEmployeeJobDepartmentDetailPersistenceManager
    {
        SqlDbContext db = new SqlDbContext();

        public Employee Create(Employee employee)
        {
            Delete(employee);
            var employeeSelected = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            foreach (var item in employee.JobDepartments)
            {
                var employeeJobDepartmentDetailPersistenceEntity = new EmployeeJobDepartmentDetailPersistenceEntity();
                employeeJobDepartmentDetailPersistenceEntity.DepartmentID = item;
                employeeJobDepartmentDetailPersistenceEntity.EmployeeID = employeeSelected.ID;
                db.EmployeeJobDepartmentDetailPersistenceEntities.Add(employeeJobDepartmentDetailPersistenceEntity);
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
            var employeeSelected = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            var employeeJobDepartmentDetailPersistenceEntity = db.EmployeeJobDepartmentDetailPersistenceEntities.Where(e => e.EmployeeID == employeeSelected.ID);
            foreach (var item in employeeJobDepartmentDetailPersistenceEntity)
            {
                db.EmployeeJobDepartmentDetailPersistenceEntities.Remove(item);
            }

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
