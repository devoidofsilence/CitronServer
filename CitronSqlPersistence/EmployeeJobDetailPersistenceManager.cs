using CitronInfrastructure.PersistenceManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitronAppCore.DomainEntities;
using CitronSqlPersistence.PersistenceEntities;
using CitronWeb.Utils;

namespace CitronSqlPersistence
{
    public class EmployeeJobDetailPersistenceManager : IEmployeeJobDetailPersistenceManager
    {
        SqlDbContext db = new SqlDbContext();
        public Employee Create(Employee employee)
        {
            var dh = new TempDataHolder();
            if (!string.IsNullOrEmpty(employee.JobDesignationCode))
            {
                var jobDesignationPersistenceEntity = db.JobDesignationPersistenceEntities.FirstOrDefault(e => e.Code == employee.JobDesignationCode);
                if (jobDesignationPersistenceEntity != null)
                {
                    dh.jobDesignationID = jobDesignationPersistenceEntity.ID;
                }
            }
            var employeeSelected = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            var employeeJobDetailPersistenceEntity = new EmployeeJobDetailPersistenceEntity()
            {
                EmployeeID = employeeSelected.ID,
                DesignationID = dh.jobDesignationID,
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
            var dh = new TempDataHolder();

            if (!string.IsNullOrEmpty(employee.JobDesignationCode))
            {
                var jobDesignationPersistenceEntity = db.JobDesignationPersistenceEntities.FirstOrDefault(e => e.Code == employee.JobDesignationCode);
                if (jobDesignationPersistenceEntity != null)
                {
                    dh.jobDesignationID = jobDesignationPersistenceEntity.ID;
                }
            }
            var employeeSelected = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            var employeeJobDetailPersistenceEntity = db.EmployeeJobDetailPersistenceEntities.FirstOrDefault(e => e.EmployeeID == employeeSelected.ID);
            employeeJobDetailPersistenceEntity.DesignationID = dh.jobDesignationID;
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

        public Employee Find(string code)
        {
            var dh = new TempDataHolder();
            Employee employee = new Employee();

            var aggregatedTable = (from empTable in db.EmployeePersistenceEntities.Where(e => e.Code == code)
                                   join employeeJobDetailTable in db.EmployeeJobDetailPersistenceEntities on empTable.ID equals employeeJobDetailTable.EmployeeID into eejdJoin
                                   from eejd in eejdJoin.DefaultIfEmpty()
                                   join employeeJobDepartmentDetailTable in db.EmployeeJobDepartmentDetailPersistenceEntities on eejd.EmployeeID equals employeeJobDepartmentDetailTable.EmployeeID into ejddeejdJoin
                                   from ejddeejd in ejddeejdJoin.DefaultIfEmpty()
                                   join jdTable in db.JobDepartmentPersistenceEntities on ejddeejd.DepartmentID equals jdTable.ID into jdejddeejdJoin
                                   from jdejddeejd in jdejddeejdJoin.DefaultIfEmpty()
                                   join jdesigTable in db.JobDesignationPersistenceEntities on eejd.DesignationID equals jdesigTable.ID into jdejddeejdjdesigJoin
                                   from jdejddeejdjdesig in jdejddeejdjdesigJoin.DefaultIfEmpty()
                                   select new { Employee = empTable, EmployeeJobDetail = eejd, EmployeeJobDepartmentDetail = ejddeejd, JobDepartments = jdejddeejd, JobDesignation = jdejddeejdjdesig });
            var sqlQ = aggregatedTable.ToString();

            var tt = aggregatedTable.ToList();

            if (aggregatedTable != null)
            {
                if (aggregatedTable.FirstOrDefault().Employee != null)
                {
                    dh.byteString = null;
                    var aggEmployeeTblValue = aggregatedTable.FirstOrDefault().Employee;
                    employee.Code = code;
                    employee.Name = aggEmployeeTblValue.Name;
                    if (aggEmployeeTblValue.Photo != null)
                    {
                        dh.byteString = Encoding.ASCII.GetString(aggEmployeeTblValue.Photo);
                        employee.Photo = dh.byteString;
                    }
                }
                if (aggregatedTable.FirstOrDefault().JobDesignation != null)
                {
                    var aggEmployeeJobDesigTblValue = aggregatedTable.FirstOrDefault().JobDesignation;
                    employee.JobDesignationCode = aggEmployeeJobDesigTblValue.Code;
                }
                if (aggregatedTable.FirstOrDefault().EmployeeJobDetail != null)
                {
                    var aggEmployeeJobDtlTblValue = aggregatedTable.FirstOrDefault().EmployeeJobDetail;
                    employee.JobDetailsExist = aggEmployeeJobDtlTblValue != null ? true : false;
                    employee.OfficeJoinDate = aggEmployeeJobDtlTblValue.OfficeJoinDate == null ? string.Empty : aggEmployeeJobDtlTblValue.OfficeJoinDate.DateToString();
                    employee.JobDescription = aggEmployeeJobDtlTblValue.Description;
                    employee.ExperienceYearsOnOfficeJoin = aggEmployeeJobDtlTblValue.ExperienceYearsOnOfficeJoin;
                    employee.ExperienceMonthsOnOfficeJoin = aggEmployeeJobDtlTblValue.ExperienceMonthsOnOfficeJoin;
                }
                if (aggregatedTable.FirstOrDefault().EmployeeJobDepartmentDetail != null)
                {
                    var aggEmployeeJobDptDtlTblValue = aggregatedTable.Select(e => e.EmployeeJobDepartmentDetail);
                    employee.JobDepartments = new List<string>();
                    var tableDptDtl = aggEmployeeJobDptDtlTblValue.ToList();
                    if (aggEmployeeJobDptDtlTblValue != null && tableDptDtl.Count != 0)
                    {
                        foreach (var item in aggEmployeeJobDptDtlTblValue)
                        {
                            employee.JobDepartments.Add(item.jobDepartmentPersistenceEntity.Code);
                        }
                    }
                }
                if (aggregatedTable.FirstOrDefault().JobDepartments != null)
                {
                    var aggJobDptsTblValue = aggregatedTable.FirstOrDefault().JobDepartments;
                }
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

        public int ReadPrimaryKey(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
