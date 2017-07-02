using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronSqlPersistence.PersistenceEntities
{
    public class ProjectTaskAssignedEmployeesPersistenceEntity
    {
        public int ID { get; set; }
        [Required]
        [ForeignKey("employeePersistenceEntity")]
        public int EmployeeID { get; set; }
        public EmployeePersistenceEntity employeePersistenceEntity { get; set; }
        //[Required]
        [ForeignKey("projectTaskPersistenceEntity")]
        public int? ProjectTskID { get; set; }
        public ProjectTaskPersistenceEntity projectTaskPersistenceEntity { get; set; }
    }
}
