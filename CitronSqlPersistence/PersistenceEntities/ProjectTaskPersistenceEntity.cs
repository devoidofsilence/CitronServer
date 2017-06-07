using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronSqlPersistence.PersistenceEntities
{
    public class ProjectTaskPersistenceEntity
    {
        public int ID { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(10)]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [ForeignKey("projectPersistenceEntity")]
        public int? ProjectID { get; set; }
        public ProjectPersistenceEntity projectPersistenceEntity { get; set; }
        [ForeignKey("responsibleEmployeePersistenceEntity")]
        public int? ResponsibleEmployeeID { get; set; }
        public EmployeePersistenceEntity responsibleEmployeePersistenceEntity { get; set; }
        //Maybe other accountable employees too, to be implemented later
        public int OptimisticTime { get; set; }
        public int PessimisticTime { get; set; }
        public int NormalTime { get; set; }
        public int ExpectedTime { get; set; }
        public int? ParentProjectTaskID { get; set; }
    }
}
