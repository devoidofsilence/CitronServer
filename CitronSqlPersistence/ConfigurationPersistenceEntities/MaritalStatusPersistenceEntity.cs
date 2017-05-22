using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronSqlPersistence.ConfigurationPersistenceEntities
{
    public class MaritalStatusPersistenceEntity
    {
        public int ID { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(10)]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
