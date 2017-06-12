using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronSqlPersistence.PersistenceEntities
{
    public class StakeholderPersistenceEntity
    {
        public int ID { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(10)]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string OrganizationName { get; set; }
        public string JobPosition { get; set; }
    }
}
