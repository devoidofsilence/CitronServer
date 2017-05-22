using System;
using System.Collections.Generic;
using CitronAppCore.DomainEntities;
using CitronInfrastructure.PersistenceManagers;
using CitronSqlPersistence.PersistenceEntities;
using System.Linq;

namespace CitronSqlPersistence
{
    public class EmployeePersistenceManager : IEmployeePersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public Employee Create(Employee employee)
        {
            var employeePersistenceEntity = new EmployeePersistenceEntity()
            {
                Code = employee.Code,
                Name = employee.Name,
                Photo = employee.Photo,
                Birthday = Convert.ToDateTime(employee.Birthday),
                MaritalStatus = string.IsNullOrEmpty(employee.MaritalStatus) ? (int?)null : int.Parse(employee.MaritalStatus),
                PersonalityType = string.IsNullOrEmpty(employee.PersonalityType) ? (int?)null : int.Parse(employee.PersonalityType),
                BloodGroup = string.IsNullOrEmpty(employee.BloodGroup) ? (int?)null : int.Parse(employee.BloodGroup),
                CitizenshipNo = employee.CitizenshipNo,
                EmailId = employee.EmailId,
                LocalAddress = employee.LocalAddress,
                LocalAddressContactNo = employee.LocalAddressContactNo,
                PermanentAddress = employee.PermanentAddress,
                PermanentAddressContactNo = employee.PermanentAddressContactNo,
                EmergencyAddress = employee.EmergencyAddress,
                EmergencyAddressContactNo = employee.EmergencyAddressContactNo,
                GooglePlusLink = employee.GooglePlusLink,
                FacebookLink = employee.FacebookLink,
                TwitterLink = employee.TwitterLink,
                LinkedInLink = employee.LinkedInLink
            };

            db.EmployeePersistenceEntities.Add(employeePersistenceEntity);
            db.SaveChanges();
            return employee;
        }

        public Employee Update(Employee employee)
        {
            var employeePersistenceEntity = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            employeePersistenceEntity.Code = employee.Code;
            employeePersistenceEntity.Name = employee.Name;
            employeePersistenceEntity.Photo = employee.Photo;
            employeePersistenceEntity.Birthday = Convert.ToDateTime(employee.Birthday);
            employeePersistenceEntity.MaritalStatus = string.IsNullOrEmpty(employee.MaritalStatus) ? (int?)null : int.Parse(employee.MaritalStatus);
            employeePersistenceEntity.PersonalityType = string.IsNullOrEmpty(employee.PersonalityType) ? (int?)null : int.Parse(employee.PersonalityType);
            employeePersistenceEntity.BloodGroup = string.IsNullOrEmpty(employee.BloodGroup) ? (int?)null : int.Parse(employee.BloodGroup);
            employeePersistenceEntity.CitizenshipNo = employee.CitizenshipNo;
            employeePersistenceEntity.EmailId = employee.EmailId;
            employeePersistenceEntity.LocalAddress = employee.LocalAddress;
            employeePersistenceEntity.LocalAddressContactNo = employee.LocalAddressContactNo;
            employeePersistenceEntity.LocalAddressMobileNo = employee.LocalAddressMobileNo;
            employeePersistenceEntity.PermanentAddress = employee.PermanentAddress;
            employeePersistenceEntity.PermanentAddressContactNo = employee.PermanentAddressContactNo;
            employeePersistenceEntity.PermanentAddressMobileNo = employee.PermanentAddressMobileNo;
            employeePersistenceEntity.EmergencyAddress = employee.EmergencyAddress;
            employeePersistenceEntity.EmergencyAddressContactNo = employee.EmergencyAddressContactNo;
            employeePersistenceEntity.EmergencyAddressMobileNo = employee.EmergencyAddressMobileNo;
            employeePersistenceEntity.GooglePlusLink = employee.GooglePlusLink;
            employeePersistenceEntity.FacebookLink = employee.FacebookLink;
            employeePersistenceEntity.TwitterLink = employee.TwitterLink;
            employeePersistenceEntity.LinkedInLink = employee.LinkedInLink;

            db.SaveChanges();
            return employee;
        }

        public Employee Delete(Employee employee)
        {
            var employeePersistenceEntity = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            db.EmployeePersistenceEntities.Remove(employeePersistenceEntity);

            db.SaveChanges();
            return employee;
        }

        public Employee Find(string id)
        {
            var employeePersistenceEntity = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == id);
            Employee employee = new Employee() { Code = employeePersistenceEntity.Code };
            return employee;
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
