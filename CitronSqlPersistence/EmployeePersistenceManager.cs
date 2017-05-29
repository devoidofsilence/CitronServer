using System;
using System.Collections.Generic;
using CitronAppCore.DomainEntities;
using CitronInfrastructure.PersistenceManagers;
using CitronSqlPersistence.PersistenceEntities;
using System.Linq;
using System.Data;
using System.Data.Entity;
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

        public int? parentTaskID = null;
        public int? responsibleEmployeeID = null;

        public string parentTaskCode = null;
        public string responsibleEmployeeCode = null;
    }

    public class EmployeePersistenceManager : IEmployeePersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public Employee Create(Employee employee)
        {
            var dh = new TempDataHolder();

            if (!string.IsNullOrEmpty(employee.MaritalStatusCode))
            {
                var maritalStatusPersistenceEntity = db.MaritalStatusPersistenceEntities.FirstOrDefault(e => e.Code == employee.MaritalStatusCode);
                if (maritalStatusPersistenceEntity != null)
                {
                    dh.maritalStatusID = maritalStatusPersistenceEntity.ID;
                }
            }

            if (!string.IsNullOrEmpty(employee.PersonalityTypeCode))
            {
                var personalityTypePersistenceEntity = db.PersonalityTypePersistenceEntities.FirstOrDefault(e => e.Code == employee.PersonalityTypeCode);
                if (personalityTypePersistenceEntity != null)
                {
                    dh.personalityTypeID = personalityTypePersistenceEntity.ID;
                }
            }

            if (!string.IsNullOrEmpty(employee.BloodGroupCode))
            {
                var bloodGroupPersistenceEntity = db.BloodGroupPersistenceEntities.FirstOrDefault(e => e.Code == employee.BloodGroupCode);
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
            if (!string.IsNullOrEmpty(employee.MaritalStatusCode))
            {
                var maritalStatusPersistenceEntity = db.MaritalStatusPersistenceEntities.FirstOrDefault(e => e.Code == employee.MaritalStatusCode);
                if (maritalStatusPersistenceEntity != null)
                {
                    dh.maritalStatusID = maritalStatusPersistenceEntity.ID;
                }
            }

            if (!string.IsNullOrEmpty(employee.PersonalityTypeCode))
            {
                var personalityTypePersistenceEntity = db.PersonalityTypePersistenceEntities.FirstOrDefault(e => e.Code == employee.PersonalityTypeCode);
                if (personalityTypePersistenceEntity != null)
                {
                    dh.personalityTypeID = personalityTypePersistenceEntity.ID;
                }
            }

            if (!string.IsNullOrEmpty(employee.BloodGroupCode))
            {
                var bloodGroupPersistenceEntity = db.BloodGroupPersistenceEntities.FirstOrDefault(e => e.Code == employee.BloodGroupCode);
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
            var employeePersistenceEntity = db.EmployeePersistenceEntities.Where(e => e.Code == code);

            var aggregatedTable = (from empTable in employeePersistenceEntity
                                   join maritalTable in db.MaritalStatusPersistenceEntities on empTable.MaritalStatus equals maritalTable.ID into emJoin
                                   from em in emJoin.DefaultIfEmpty()
                                   join ptTable in db.PersonalityTypePersistenceEntities on empTable.PersonalityType equals ptTable.ID into pemJoin
                                   from pem in pemJoin.DefaultIfEmpty()
                                   join bgTable in db.BloodGroupPersistenceEntities on empTable.PersonalityType equals bgTable.ID into bpemJoin
                                   from bpem in bpemJoin.DefaultIfEmpty()
                                   join ejdTable in db.EmployeeJobDetailPersistenceEntities on empTable.ID equals ejdTable.EmployeeID into ejdemJoin
                                   from ejdem in ejdemJoin.DefaultIfEmpty()
                                   select new { Employee = empTable, MaritalStatus = em, PersonalityType = pem, BloodGroup = bpem, EmployeeJobDetail = ejdem });

            var tt = aggregatedTable.ToList();

            Employee employee = new Employee();
            if (aggregatedTable != null)
            {
                //if (aggregatedTable.Employee.MaritalStatus != null)
                //{
                //    var maritalStatusPersistenceEntity = db.MaritalStatusPersistenceEntities.FirstOrDefault(e => e.ID == employeePersistenceEntity.Employee.MaritalStatus);
                //    if (maritalStatusPersistenceEntity != null)
                //    {
                //        dh.maritalStatusCode = maritalStatusPersistenceEntity.Code;
                //    }
                //}

                //if (employeePersistenceEntity.PersonalityType != null)
                //{
                //    var personalityTypePersistenceEntity = db.PersonalityTypePersistenceEntities.FirstOrDefault(e => e.ID == employeePersistenceEntity.PersonalityType);
                //    if (personalityTypePersistenceEntity != null)
                //    {
                //        dh.personalityTypeCode = personalityTypePersistenceEntity.Code;
                //    }
                //}

                //if (employeePersistenceEntity.BloodGroup != null)
                //{
                //    var bloodGroupPersistenceEntity = db.BloodGroupPersistenceEntities.FirstOrDefault(e => e.ID == employeePersistenceEntity.BloodGroup);
                //    if (bloodGroupPersistenceEntity != null)
                //    {
                //        dh.bloodGroupCode = bloodGroupPersistenceEntity.Code;
                //    }
                //}

                //if (employeePersistenceEntity.Photo != null)
                //{
                //    dh.byteString = Encoding.ASCII.GetString(employeePersistenceEntity.Photo);
                //}

                //employee.Code = employeePersistenceEntity.Code;
                //employee.Name = employeePersistenceEntity.Name;
                //employee.Photo = dh.byteString;
                //employee.Birthday = employeePersistenceEntity.Birthday.DateToString();
                //employee.MaritalStatusCode = dh.maritalStatusCode;
                //employee.PersonalityTypeCode = dh.personalityTypeCode;
                //employee.BloodGroupCode = dh.bloodGroupCode;
                //employee.CitizenshipNo = employeePersistenceEntity.CitizenshipNo.NullIfEmptyString();
                //employee.EmailId = employeePersistenceEntity.EmailId.NullIfEmptyString();
                //employee.LocalAddress = employeePersistenceEntity.LocalAddress.NullIfEmptyString();
                //employee.LocalAddressContactNo = employeePersistenceEntity.LocalAddressContactNo.NullIfEmptyString();
                //employee.LocalAddressMobileNo = employeePersistenceEntity.LocalAddressMobileNo.NullIfEmptyString();
                //employee.PermanentAddress = employeePersistenceEntity.PermanentAddress.NullIfEmptyString();
                //employee.PermanentAddressContactNo = employeePersistenceEntity.PermanentAddressContactNo.NullIfEmptyString();
                //employee.PermanentAddressMobileNo = employeePersistenceEntity.PermanentAddressMobileNo.NullIfEmptyString();
                //employee.EmergencyAddress = employeePersistenceEntity.EmergencyAddress.NullIfEmptyString();
                //employee.EmergencyAddressContactNo = employeePersistenceEntity.EmergencyAddressContactNo.NullIfEmptyString();
                //employee.EmergencyAddressMobileNo = employeePersistenceEntity.EmergencyAddressMobileNo.NullIfEmptyString();
                //employee.GooglePlusLink = employeePersistenceEntity.GooglePlusLink.NullIfEmptyString();
                //employee.FacebookLink = employeePersistenceEntity.FacebookLink.NullIfEmptyString();
                //employee.TwitterLink = employeePersistenceEntity.TwitterLink.NullIfEmptyString();
                //employee.LinkedInLink = employeePersistenceEntity.LinkedInLink.NullIfEmptyString();
            }
            return employee;
        }

        public IList<Employee> FindAll(Func<Employee, bool> condition)
        {
            var dh = new TempDataHolder();
            IList<Employee> employeesList = new List<Employee>();

            var aggregatedTable = (from empTable in db.EmployeePersistenceEntities
                                   join maritalTable in db.MaritalStatusPersistenceEntities on empTable.MaritalStatus equals maritalTable.ID into emJoin
                                   from em in emJoin.DefaultIfEmpty()
                                   join ptTable in db.PersonalityTypePersistenceEntities on empTable.PersonalityType equals ptTable.ID into pemJoin
                                   from pem in pemJoin.DefaultIfEmpty()
                                   join bgTable in db.BloodGroupPersistenceEntities on empTable.PersonalityType equals bgTable.ID into bpemJoin
                                   from bpem in bpemJoin.DefaultIfEmpty()
                                   join ejdTable in db.EmployeeJobDetailPersistenceEntities on empTable.ID equals ejdTable.EmployeeID into ejdemJoin
                                   from ejdem in ejdemJoin.DefaultIfEmpty()
                                   select new { Employee = empTable, MaritalStatus = em, PersonalityType = pem, BloodGroup = bpem, EmployeeJobDetail = ejdem });

            var tt = aggregatedTable.ToList();

            foreach (var employeePersistenceEntity in aggregatedTable)
            {
                dh.byteString = null;
                if (employeePersistenceEntity.Employee.Photo != null)
                {
                    dh.byteString = Encoding.ASCII.GetString(employeePersistenceEntity.Employee.Photo);
                }
                employeesList.Add(new Employee()
                {
                    Code = employeePersistenceEntity.Employee.Code,
                    Name = employeePersistenceEntity.Employee.Name,
                    Photo = dh.byteString,
                    Birthday = employeePersistenceEntity.Employee.Birthday.DateToString(),
                    MaritalStatusCode = employeePersistenceEntity.MaritalStatus == null ? null : employeePersistenceEntity.MaritalStatus.Code,
                    PersonalityTypeCode = employeePersistenceEntity.PersonalityType == null ? null : employeePersistenceEntity.PersonalityType.Code,
                    BloodGroupCode = employeePersistenceEntity.BloodGroup == null ? null : employeePersistenceEntity.BloodGroup.Code,
                    DesignationName = employeePersistenceEntity.EmployeeJobDetail == null ? null : employeePersistenceEntity.EmployeeJobDetail.Description,
                    ExperienceYearsOnOfficeJoin = employeePersistenceEntity.EmployeeJobDetail == null ? null : employeePersistenceEntity.EmployeeJobDetail.ExperienceYearsOnOfficeJoin,
                    CitizenshipNo = employeePersistenceEntity.Employee.CitizenshipNo.NullIfEmptyString(),
                    EmailId = employeePersistenceEntity.Employee.EmailId.NullIfEmptyString(),
                    LocalAddress = employeePersistenceEntity.Employee.LocalAddress.NullIfEmptyString(),
                    LocalAddressContactNo = employeePersistenceEntity.Employee.LocalAddressContactNo.NullIfEmptyString(),
                    LocalAddressMobileNo = employeePersistenceEntity.Employee.LocalAddressMobileNo.NullIfEmptyString(),
                    PermanentAddress = employeePersistenceEntity.Employee.PermanentAddress.NullIfEmptyString(),
                    PermanentAddressContactNo = employeePersistenceEntity.Employee.PermanentAddressContactNo.NullIfEmptyString(),
                    PermanentAddressMobileNo = employeePersistenceEntity.Employee.PermanentAddressMobileNo.NullIfEmptyString(),
                    EmergencyAddress = employeePersistenceEntity.Employee.EmergencyAddress.NullIfEmptyString(),
                    EmergencyAddressContactNo = employeePersistenceEntity.Employee.EmergencyAddressContactNo.NullIfEmptyString(),
                    EmergencyAddressMobileNo = employeePersistenceEntity.Employee.EmergencyAddressMobileNo.NullIfEmptyString(),
                    GooglePlusLink = employeePersistenceEntity.Employee.GooglePlusLink.NullIfEmptyString(),
                    FacebookLink = employeePersistenceEntity.Employee.FacebookLink.NullIfEmptyString(),
                    TwitterLink = employeePersistenceEntity.Employee.TwitterLink.NullIfEmptyString(),
                    LinkedInLink = employeePersistenceEntity.Employee.LinkedInLink.NullIfEmptyString()
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
