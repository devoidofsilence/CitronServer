using CitronSqlPersistence.ConfigurationPersistenceEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronSqlPersistence.PersistenceEntities
{
    public class ProjectCharterPersistenceEntity
    {
        public int ID { get; set; }
        //[Required]
        //[Index(IsUnique = true)]
        //[MaxLength(10)]
        //public string Code { get; set; }
        [Required]
        [ForeignKey("projectPersistenceEntity")]
        public int ProjectID { get; set; }
        public ProjectPersistenceEntity projectPersistenceEntity { get; set; }
        [Required]
        [ForeignKey("projectCharterQuestionEntity")]
        public int QuestionID { get; set; }
        public ProjectCharterQuestionPersistenceEntity projectCharterQuestionEntity { get; set; }
        public string Answer { get; set; }
    }
}
