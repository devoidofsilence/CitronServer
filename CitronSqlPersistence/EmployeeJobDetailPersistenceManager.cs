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
    public class EmployeeJobDetailPersistenceManager : IEmployeeJobDetailPersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public Employee Create(Employee employee)
        {
            var employeeSelected = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            var employeeJobDetailPersistenceEntity = new EmployeeJobDetailPersistenceEntity()
            {
                EmployeeID = employeeSelected.ID,
                DesignationID = employee.JobDesignation,
                Description = employee.JobDescription,
                OfficeJoinDate = Convert.ToDateTime(employee.OfficeJoinDate),
                ExperienceYearsOnOfficeJoin = employee.ExperienceYearsOnOfficeJoin,
                ExperienceMonthsOnOfficeJoin = employee.ExperienceMonthsOnOfficeJoin
            };

            db.EmployeeJobDetailPersistenceEntities.Add(employeeJobDetailPersistenceEntity);
            db.SaveChanges();
            return employee;
        }

        public Employee Update(Employee employee)
        {
            var employeeSelected = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            var employeeJobDetailPersistenceEntity = db.EmployeeJobDetailPersistenceEntities.FirstOrDefault(e => e.EmployeeID == employeeSelected.ID);
            employeeJobDetailPersistenceEntity.DesignationID = employee.JobDesignation;
            employeeJobDetailPersistenceEntity.Description = employee.JobDescription;
            employeeJobDetailPersistenceEntity.OfficeJoinDate = Convert.ToDateTime(employee.OfficeJoinDate);
            employeeJobDetailPersistenceEntity.ExperienceYearsOnOfficeJoin = employee.ExperienceYearsOnOfficeJoin;
            employeeJobDetailPersistenceEntity.ExperienceMonthsOnOfficeJoin = employee.ExperienceMonthsOnOfficeJoin;

            db.SaveChanges();
            return employee;
        }

        public Employee Delete(Employee employee)
        {
            var employeeSelected = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            var employeeJobDetailPersistenceEntity = db.EmployeeJobDetailPersistenceEntities.FirstOrDefault(e => e.EmployeeID == employeeSelected.ID);
            db.EmployeeJobDetailPersistenceEntities.Remove(employeeJobDetailPersistenceEntity);

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

        public int ReadPrimaryKey(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
