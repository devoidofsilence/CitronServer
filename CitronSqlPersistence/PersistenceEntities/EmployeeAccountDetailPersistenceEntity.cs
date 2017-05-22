using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronSqlPersistence.PersistenceEntities
{
    public class EmployeeAccountDetailPersistenceEntity
    {
        public int ID { get; set; }
        [ForeignKey("employeePersistenceEntity")]
        public int EmployeeID { get; set; }
        public EmployeePersistenceEntity employeePersistenceEntity { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        //[Index(IsUnique = true)]
        public string BankAccountNo { get; set; }
        public decimal SalaryWithTax { get; set; }
    }
}
