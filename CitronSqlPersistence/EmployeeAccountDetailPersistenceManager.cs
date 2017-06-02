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
            var dh = new TempDataHolder();
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
            var dh = new TempDataHolder();
            var employeeSelected = db.EmployeePersistenceEntities.FirstOrDefault(e => e.Code == employee.Code);
            var employeeAccountDetailPersistenceEntity = db.EmployeeAccountDetailPersistenceEntities.FirstOrDefault(e => e.EmployeeID == employeeSelected.ID);
            employeeAccountDetailPersistenceEntity.BankName = employee.BankName;
            employeeAccountDetailPersistenceEntity.BankBranch = employee.BankBranch;
            employeeAccountDetailPersistenceEntity.BankAccountNo = employee.BankAccountNo;
            employeeAccountDetailPersistenceEntity.SalaryWithTax = employee.SalaryWithTax; // => For ReviewofSalary only

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

        public Employee Find(string code)
        {
            var dh = new TempDataHolder();
            Employee employee = new Employee();

            var aggregatedTable = (from empTable in db.EmployeePersistenceEntities.Where(e => e.Code == code)
                                   join employeeAccountDetailTable in db.EmployeeAccountDetailPersistenceEntities on empTable.ID equals employeeAccountDetailTable.EmployeeID into eejdJoin
                                   from eead in eejdJoin.DefaultIfEmpty()
                                   join employeeAllowanceDetailTable in db.EmployeeAllowanceDetailPersistenceEntities on eead.EmployeeID equals employeeAllowanceDetailTable.EmployeeID into eadeeadJoin
                                   from eadeead in eadeeadJoin.DefaultIfEmpty()
                                   join allowanceTable in db.AllowancePersistenceEntities on eadeead.AllowanceID equals allowanceTable.ID into jdejddeejdJoin
                                   from jdejddeejd in jdejddeejdJoin.DefaultIfEmpty()
                                   select new { Employee = empTable, EmployeeAccountDetail = eead, EmployeeAllowanceDetail = eadeead, Allowances = jdejddeejd });
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
                if (aggregatedTable.FirstOrDefault().EmployeeAccountDetail != null)
                {
                    var aggEmployeeAccDtlTblValue = aggregatedTable.FirstOrDefault().EmployeeAccountDetail;
                    employee.AccountDetailsExist = aggEmployeeAccDtlTblValue != null ? true : false;
                    employee.BankName = aggEmployeeAccDtlTblValue.BankName;
                    employee.BankBranch = aggEmployeeAccDtlTblValue.BankBranch;
                    employee.BankAccountNo = aggEmployeeAccDtlTblValue.BankAccountNo;
                    employee.SalaryWithTax = aggEmployeeAccDtlTblValue.SalaryWithTax;
                }
                if (aggregatedTable.FirstOrDefault().EmployeeAllowanceDetail != null)
                {
                    var aggEmployeeAllowanceDtlTblValue = aggregatedTable.Select(e => e.EmployeeAllowanceDetail);
                    employee.Allowances = new List<string>();
                    foreach (var item in aggEmployeeAllowanceDtlTblValue)
                    {
                        employee.Allowances.Add(item.allowancePersistenceEntity.Code);
                    }
                }
                if (aggregatedTable.FirstOrDefault().Allowances != null)
                {
                    var aggAllowancesTblValue = aggregatedTable.FirstOrDefault().Allowances;
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
    }
}
