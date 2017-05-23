using System;
using System.Collections.Generic;
using CitronAppCore.DomainEntities;
using CitronInfrastructure.PersistenceManagers;
using CitronSqlPersistence.PersistenceEntities;
using System.Linq;
using CitronWeb.Utils;

namespace CitronSqlPersistence
{
    public class EmployeePersistenceManager : IEmployeePersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public Employee Create(Employee employee)
        {
            var employeePersistenceEntity = new EmployeePersistenceEntity()
            {
                Code = employee.Code.NullIfEmptyString(),
                Name = employee.Name.NullIfEmptyString(),
                Photo = employee.Photo.NullIfEmptyString(),
                Birthday = employee.Birthday.NullDateIfEmptyString(),
                MaritalStatus = employee.MaritalStatus.NullIntIfEmptyString(),
                PersonalityType = employee.PersonalityType.NullIntIfEmptyString(),
                BloodGroup = employee.BloodGroup.NullIntIfEmptyString(),
                CitizenshipNo = employee.CitizenshipNo.NullIfEmptyString(),
                EmailId = employee.EmailId.NullIfEmptyString(),
                LocalAddress = employee.LocalAddress.NullIfEmptyString(),
                LocalAddressContactNo = employee.LocalAddressContactNo.NullIfEmptyString(),
                LocalAddressMobileNo = employee.LocalAddressMobileNo.NullIfEmptyString(),
                PermanentAddress = employee.PermanentAddress.NullIfEmptyString(),
                PermanentAddressContactNo = employee.PermanentAddressContactNo.NullIfEmptyString(),
                PermanentAddressMobileNo = employee.PermanentAddressMobileNo.NullIfEmptyString(),
                EmergencyAddress = employee.EmergencyAddress.NullIfEmptyString(),
                EmergencyAddressContactNo = employee.EmergencyAddressContactNo.NullIfEmptyString(),
                EmergencyAddressMobileNo = employee.EmergencyAddressMobileNo.NullIfEmptyString(),
                GooglePlusLink = employee.GooglePlusLink.NullIfEmptyString(),
                FacebookLink = employee.FacebookLink.NullIfEmptyString(),
                TwitterLink = employee.TwitterLink.NullIfEmptyString(),
                LinkedInLink = employee.LinkedInLink.NullIfEmptyString()
            };

            db.EmployeePersistenceEntities.Add(employeePersistenceEntity);
            db.SaveChanges();
            return employee;
        }

        public Employee Update(Employee employee)
        {
            var employeePersistenceEntity = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            employeePersistenceEntity.Code = employee.Code.NullIfEmptyString();
            employeePersistenceEntity.Name = employee.Name.NullIfEmptyString();
            employeePersistenceEntity.Photo = employee.Photo.NullIfEmptyString();
            employeePersistenceEntity.Birthday = employee.Birthday.NullDateIfEmptyString();
            employeePersistenceEntity.MaritalStatus = employee.MaritalStatus.NullIntIfEmptyString();
            employeePersistenceEntity.PersonalityType = employee.PersonalityType.NullIntIfEmptyString();
            employeePersistenceEntity.BloodGroup = employee.BloodGroup.NullIntIfEmptyString();
            employeePersistenceEntity.CitizenshipNo = employee.CitizenshipNo.NullIfEmptyString();
            employeePersistenceEntity.EmailId = employee.EmailId.NullIfEmptyString();
            employeePersistenceEntity.LocalAddress = employee.LocalAddress.NullIfEmptyString();
            employeePersistenceEntity.LocalAddressContactNo = employee.LocalAddressContactNo.NullIfEmptyString();
            employeePersistenceEntity.LocalAddressMobileNo = employee.LocalAddressMobileNo.NullIfEmptyString();
            employeePersistenceEntity.PermanentAddress = employee.PermanentAddress.NullIfEmptyString();
            employeePersistenceEntity.PermanentAddressContactNo = employee.PermanentAddressContactNo.NullIfEmptyString();
            employeePersistenceEntity.PermanentAddressMobileNo = employee.PermanentAddressMobileNo.NullIfEmptyString();
            employeePersistenceEntity.EmergencyAddress = employee.EmergencyAddress.NullIfEmptyString();
            employeePersistenceEntity.EmergencyAddressContactNo = employee.EmergencyAddressContactNo.NullIfEmptyString();
            employeePersistenceEntity.EmergencyAddressMobileNo = employee.EmergencyAddressMobileNo.NullIfEmptyString();
            employeePersistenceEntity.GooglePlusLink = employee.GooglePlusLink.NullIfEmptyString();
            employeePersistenceEntity.FacebookLink = employee.FacebookLink.NullIfEmptyString();
            employeePersistenceEntity.TwitterLink = employee.TwitterLink.NullIfEmptyString();
            employeePersistenceEntity.LinkedInLink = employee.LinkedInLink.NullIfEmptyString();

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

        public Employee Find(string code)
        {
            var employeePersistenceEntity = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == code);
            Employee employee = new Employee();
            if (employeePersistenceEntity != null)
            {
                employee.Code = employeePersistenceEntity.Code;
            }
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
