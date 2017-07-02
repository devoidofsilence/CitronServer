using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronSqlPersistence.PersistenceEntities
{
    public class AssignStakeholderPersistenceEntity
    {
        public int ID { get; set; }
        //[NotMapped]
        //public string AssignStakeholderCode
        //{
        //    get { return string.Concat("ASSTK", ID); }
        //}
        [Required]
        public int? ProjectId { get; set; }
        [Required]
        public int? StakeholderId { get; set; }
        public int PowerOnProject { get; set; }
        public int InterestOnProject { get; set; }
        public bool AssignedAsKey { get; set; }
    }
}
