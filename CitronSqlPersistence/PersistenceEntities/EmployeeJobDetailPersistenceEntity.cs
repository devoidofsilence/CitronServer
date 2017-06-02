using CitronSqlPersistence.ConfigurationPersistenceEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronSqlPersistence.PersistenceEntities
{
    public class EmployeeJobDetailPersistenceEntity
    {
        public int ID { get; set; }
        [ForeignKey("employeePersistenceEntity")]
        public int EmployeeID { get; set; }
        public EmployeePersistenceEntity employeePersistenceEntity { get; set; }
        [ForeignKey("jobDesignationPersistenceEntity")]
        public int? DesignationID { get; set; }
        public JobDesignationPersistenceEntity jobDesignationPersistenceEntity { get; set; }
        public string Description { get; set; }
        public DateTime? OfficeJoinDate { get; set; }
        public int? ExperienceYearsOnOfficeJoin { get; set; }
        public int? ExperienceMonthsOnOfficeJoin { get; set; }
    }
}
