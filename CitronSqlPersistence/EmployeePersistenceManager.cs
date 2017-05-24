using System;
using System.Collections.Generic;
using CitronAppCore.DomainEntities;
using CitronInfrastructure.PersistenceManagers;
using CitronSqlPersistence.PersistenceEntities;
using System.Linq;
using CitronWeb.Utils;
using System.Text;

namespace CitronSqlPersistence
{
    class TempDataHolder
    {

        public byte[] byteArray = null;
        public int? maritalStatusID = null;
        public int? personalityTypeID = null;
        public int? bloodGroupID = null;
         
        public string byteString = null;
        public string maritalStatusCode = null;
        public string personalityTypeCode = null;
        public string bloodGroupCode = null;
    }

    public class EmployeePersistenceManager : IEmployeePersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public Employee Create(Employee employee)
        {
            var dh = new TempDataHolder();

            if (!string.IsNullOrEmpty(employee.MaritalStatus))
            {
                var maritalStatusPersistenceEntity = db.maritalStatusPersistenceEntities.FirstOrDefault(e => e.Code == employee.MaritalStatus);
                if (maritalStatusPersistenceEntity != null)
                {
                    dh.maritalStatusID = maritalStatusPersistenceEntity.ID;
                }
            }

            if (!string.IsNullOrEmpty(employee.PersonalityType))
            {
                var personalityTypePersistenceEntity = db.personalityTypePersistenceEntities.FirstOrDefault(e => e.Code == employee.PersonalityType);
                if (personalityTypePersistenceEntity != null)
                {
                    dh.personalityTypeID = personalityTypePersistenceEntity.ID;
                }
            }

            if (!string.IsNullOrEmpty(employee.BloodGroup))
            {
                var bloodGroupPersistenceEntity = db.bloodGroupPersistenceEntities.FirstOrDefault(e => e.Code == employee.BloodGroup);
                if (bloodGroupPersistenceEntity != null)
                {
                    dh.bloodGroupID = bloodGroupPersistenceEntity.ID;
                }
            }

            if (!string.IsNullOrEmpty(employee.Photo))
            {
                dh.byteArray = Encoding.ASCII.GetBytes(employee.Photo);
            }

            var employeePersistenceEntity = new EmployeePersistenceEntity()
            {
                Code = employee.Code.NullIfEmptyString(),
                Name = employee.Name.NullIfEmptyString(),
                Photo = dh.byteArray,
                Birthday = employee.Birthday.NullDateIfEmptyString(),
                MaritalStatus = dh.maritalStatusID,
                PersonalityType = dh.personalityTypeID,
                BloodGroup = dh.bloodGroupID,
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
            var dh = new TempDataHolder();
            if (!string.IsNullOrEmpty(employee.MaritalStatus))
            {
                var maritalStatusPersistenceEntity = db.maritalStatusPersistenceEntities.FirstOrDefault(e => e.Code == employee.MaritalStatus);
                if (maritalStatusPersistenceEntity != null)
                {
                    dh.maritalStatusID = maritalStatusPersistenceEntity.ID;
                }
            }

            if (!string.IsNullOrEmpty(employee.PersonalityType))
            {
                var personalityTypePersistenceEntity = db.personalityTypePersistenceEntities.FirstOrDefault(e => e.Code == employee.PersonalityType);
                if (personalityTypePersistenceEntity != null)
                {
                    dh.personalityTypeID = personalityTypePersistenceEntity.ID;
                }
            }

            if (!string.IsNullOrEmpty(employee.BloodGroup))
            {
                var bloodGroupPersistenceEntity = db.bloodGroupPersistenceEntities.FirstOrDefault(e => e.Code == employee.BloodGroup);
                if (bloodGroupPersistenceEntity != null)
                {
                    dh.bloodGroupID = bloodGroupPersistenceEntity.ID;
                }
            }

            if (!string.IsNullOrEmpty(employee.Photo))
            {
                dh.byteArray = Encoding.ASCII.GetBytes(employee.Photo);
            }

            var employeePersistenceEntity = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            employeePersistenceEntity.Code = employee.Code.NullIfEmptyString();
            employeePersistenceEntity.Name = employee.Name.NullIfEmptyString();
            employeePersistenceEntity.Photo = dh.byteArray;
            employeePersistenceEntity.Birthday = employee.Birthday.NullDateIfEmptyString();
            employeePersistenceEntity.MaritalStatus = dh.maritalStatusID;
            employeePersistenceEntity.PersonalityType = dh.personalityTypeID;
            employeePersistenceEntity.BloodGroup = dh.bloodGroupID;
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
            var dh = new TempDataHolder();
            var employeePersistenceEntity = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == code);

            Employee employee = new Employee();
            if (employeePersistenceEntity != null)
            {
                if (employeePersistenceEntity.MaritalStatus != null)
                {
                    var maritalStatusPersistenceEntity = db.maritalStatusPersistenceEntities.FirstOrDefault(e => e.ID == employeePersistenceEntity.MaritalStatus);
                    if (maritalStatusPersistenceEntity != null)
                    {
                        dh.maritalStatusCode = maritalStatusPersistenceEntity.Code;
                    }
                }

                if (employeePersistenceEntity.PersonalityType != null)
                {
                    var personalityTypePersistenceEntity = db.personalityTypePersistenceEntities.FirstOrDefault(e => e.ID == employeePersistenceEntity.PersonalityType);
                    if (personalityTypePersistenceEntity != null)
                    {
                        dh.personalityTypeCode = personalityTypePersistenceEntity.Code;
                    }
                }

                if (employeePersistenceEntity.BloodGroup != null)
                {
                    var bloodGroupPersistenceEntity = db.bloodGroupPersistenceEntities.FirstOrDefault(e => e.ID == employeePersistenceEntity.BloodGroup);
                    if (bloodGroupPersistenceEntity != null)
                    {
                        dh.bloodGroupCode = bloodGroupPersistenceEntity.Code;
                    }
                }

                if (employeePersistenceEntity.Photo != null)
                {
                    dh.byteString = Encoding.ASCII.GetString(employeePersistenceEntity.Photo);
                }

                employee.Code = employeePersistenceEntity.Code;
                employee.Name = employeePersistenceEntity.Name;
                employee.Photo = dh.byteString;
                employee.Birthday = employeePersistenceEntity.Birthday.DateToString();
                employee.MaritalStatus = dh.maritalStatusCode;
                employee.PersonalityType = dh.personalityTypeCode;
                employee.BloodGroup = dh.bloodGroupCode;
                employee.CitizenshipNo = employeePersistenceEntity.CitizenshipNo.NullIfEmptyString();
                employee.EmailId = employeePersistenceEntity.EmailId.NullIfEmptyString();
                employee.LocalAddress = employeePersistenceEntity.LocalAddress.NullIfEmptyString();
                employee.LocalAddressContactNo = employeePersistenceEntity.LocalAddressContactNo.NullIfEmptyString();
                employee.LocalAddressMobileNo = employeePersistenceEntity.LocalAddressMobileNo.NullIfEmptyString();
                employee.PermanentAddress = employeePersistenceEntity.PermanentAddress.NullIfEmptyString();
                employee.PermanentAddressContactNo = employeePersistenceEntity.PermanentAddressContactNo.NullIfEmptyString();
                employee.PermanentAddressMobileNo = employeePersistenceEntity.PermanentAddressMobileNo.NullIfEmptyString();
                employee.EmergencyAddress = employeePersistenceEntity.EmergencyAddress.NullIfEmptyString();
                employee.EmergencyAddressContactNo = employeePersistenceEntity.EmergencyAddressContactNo.NullIfEmptyString();
                employee.EmergencyAddressMobileNo = employeePersistenceEntity.EmergencyAddressMobileNo.NullIfEmptyString();
                employee.GooglePlusLink = employeePersistenceEntity.GooglePlusLink.NullIfEmptyString();
                employee.FacebookLink = employeePersistenceEntity.FacebookLink.NullIfEmptyString();
                employee.TwitterLink = employeePersistenceEntity.TwitterLink.NullIfEmptyString();
                employee.LinkedInLink = employeePersistenceEntity.LinkedInLink.NullIfEmptyString();
            }
            return employee;
        }

        public IList<Employee> FindAll(Func<Employee, bool> condition)
        {
            var dh = new TempDataHolder();
            IList<Employee> employeesList = new List<Employee>();
            var employeePersistenceEntities = db.EmployeePersistenceEntities;
            var maritalStatusPersistenceEntities = db.maritalStatusPersistenceEntities;
            var personalityTypePersistenceEntities = db.personalityTypePersistenceEntities;
            var bloodGroupPersistenceEntities = db.bloodGroupPersistenceEntities;
            foreach (var employeePersistenceEntity in employeePersistenceEntities)
            {
                if (employeePersistenceEntity.MaritalStatus != null)
                {
                    var maritalStatusPersistenceEntity = maritalStatusPersistenceEntities.FirstOrDefault(e => e.ID == employeePersistenceEntity.MaritalStatus);
                    if (maritalStatusPersistenceEntity != null)
                    {
                        dh.maritalStatusCode = maritalStatusPersistenceEntity.Code;
                    }
                }

                if (employeePersistenceEntity.PersonalityType != null)
                {
                    var personalityTypePersistenceEntity = personalityTypePersistenceEntities.FirstOrDefault(e => e.ID == employeePersistenceEntity.PersonalityType);
                    if (personalityTypePersistenceEntity != null)
                    {
                        dh.personalityTypeCode = personalityTypePersistenceEntity.Code;
                    }
                }

                if (employeePersistenceEntity.BloodGroup != null)
                {
                    var bloodGroupPersistenceEntity = bloodGroupPersistenceEntities.FirstOrDefault(e => e.ID == employeePersistenceEntity.BloodGroup);
                    if (bloodGroupPersistenceEntity != null)
                    {
                        dh.bloodGroupCode = bloodGroupPersistenceEntity.Code;
                    }
                }

                if (employeePersistenceEntity.Photo != null)
                {
                    dh.byteString = Encoding.ASCII.GetString(employeePersistenceEntity.Photo);
                }
                employeesList.Add(new Employee()
                {
                    Code = employeePersistenceEntity.Code,
                    Name = employeePersistenceEntity.Name,
                    Photo = dh.byteString,
                    Birthday = employeePersistenceEntity.Birthday.DateToString(),
                    MaritalStatus = dh.maritalStatusCode,
                    PersonalityType = dh.personalityTypeCode,
                    BloodGroup = dh.bloodGroupCode,
                    CitizenshipNo = employeePersistenceEntity.CitizenshipNo.NullIfEmptyString(),
                    EmailId = employeePersistenceEntity.EmailId.NullIfEmptyString(),
                    LocalAddress = employeePersistenceEntity.LocalAddress.NullIfEmptyString(),
                    LocalAddressContactNo = employeePersistenceEntity.LocalAddressContactNo.NullIfEmptyString(),
                    LocalAddressMobileNo = employeePersistenceEntity.LocalAddressMobileNo.NullIfEmptyString(),
                    PermanentAddress = employeePersistenceEntity.PermanentAddress.NullIfEmptyString(),
                    PermanentAddressContactNo = employeePersistenceEntity.PermanentAddressContactNo.NullIfEmptyString(),
                    PermanentAddressMobileNo = employeePersistenceEntity.PermanentAddressMobileNo.NullIfEmptyString(),
                    EmergencyAddress = employeePersistenceEntity.EmergencyAddress.NullIfEmptyString(),
                    EmergencyAddressContactNo = employeePersistenceEntity.EmergencyAddressContactNo.NullIfEmptyString(),
                    EmergencyAddressMobileNo = employeePersistenceEntity.EmergencyAddressMobileNo.NullIfEmptyString(),
                    GooglePlusLink = employeePersistenceEntity.GooglePlusLink.NullIfEmptyString(),
                    FacebookLink = employeePersistenceEntity.FacebookLink.NullIfEmptyString(),
                    TwitterLink = employeePersistenceEntity.TwitterLink.NullIfEmptyString(),
                    LinkedInLink = employeePersistenceEntity.LinkedInLink.NullIfEmptyString()
                });
            }
            return employeesList;
        }

        public Employee Read(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
