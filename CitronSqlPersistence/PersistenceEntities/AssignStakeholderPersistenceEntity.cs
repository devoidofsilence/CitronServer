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
        public string ProjectCode { get; set; }
        [Required]
        public string StakeholderCode { get; set; }
        public string PowerOnProject { get; set; }
        public string InterestOnProject { get; set; }
        public string AssignedAsKey { get; set; }
    }
}
