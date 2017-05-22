using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronSqlPersistence.PersistenceEntities
{
    public class EmployeePersistenceEntity
    {
        //General Detail
        public int ID { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(10)]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string Photo { get; set; }
        public DateTime? Birthday { get; set; }
        public int? MaritalStatus { get; set; }
        public int? PersonalityType { get; set; }
        public int? BloodGroup { get; set; }
        public string CitizenshipNo { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(200)]
        public string EmailId { get; set; }
        public string LocalAddress { get; set; }
        public string LocalAddressContactNo { get; set; }
        public string LocalAddressMobileNo { get; set; }
        public string PermanentAddress { get; set; }
        public string PermanentAddressContactNo { get; set; }
        public string PermanentAddressMobileNo { get; set; }
        public string EmergencyAddress { get; set; }
        public string EmergencyAddressContactNo { get; set; }
        public string EmergencyAddressMobileNo { get; set; }
        //Social Network Links
        public string GooglePlusLink { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }
    }
}