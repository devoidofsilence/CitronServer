using CitronSqlPersistence.ConfigurationPersistenceEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronSqlPersistence.PersistenceEntities
{
    public class EmployeeJobDepartmentDetailPersistenceEntity
    {
        public int ID { get; set; }
        [ForeignKey("employeePersistenceEntity")]
        public int? EmployeeID { get; set; }
        public EmployeePersistenceEntity employeePersistenceEntity { get; set; }
        [ForeignKey("jobDepartmentPersistenceEntity")]
        public int? DepartmentID { get; set; }
        public JobDepartmentPersistenceEntity jobDepartmentPersistenceEntity { get; set; }
    }
}
