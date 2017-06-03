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
        public byte[] Photo { get; set; }
        public DateTime? Birthday { get; set; }
        [ForeignKey("maritalStatusPersistenceEntity")]
        public int? MaritalStatus { get; set; }
        public MaritalStatusPersistenceEntity maritalStatusPersistenceEntity { get; set; }
        [ForeignKey("personalityTypePersistenceEntity")]
        public int? PersonalityType { get; set; }
        public PersonalityTypePersistenceEntity personalityTypePersistenceEntity { get; set; }
        [ForeignKey("bloodGroupPersistenceEntity")]
        public int? BloodGroup { get; set; }
        public BloodGroupPersistenceEntity bloodGroupPersistenceEntity { get; set; }
        public string CitizenshipNo { get; set; }
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