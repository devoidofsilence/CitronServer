using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronSqlPersistence.ConfigurationPersistenceEntities
{
    public class ProjectCharterQuestionPersistenceEntity
    {
        public int ID { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(10)]
        public string Code { get; set; }
        [Required]
        [ForeignKey("projectCharterQuestionHeaderEntity")]
        public int HeaderID { get; set; }
        public ProjectCharterQuestionHeaderPersistenceEntity projectCharterQuestionHeaderEntity { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
    }
}
