﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronAppCore.DomainEntities
{
    public class Employee : IDomainEntity
    {
        //General Information
        public string Code { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Birthday { get; set; }
        public string MaritalStatusCode { get; set; }
        public string PersonalityTypeCode { get; set; }
        public string BloodGroupCode { get; set; }
        public string MaritalStatusName { get; set; }
        public string PersonalityTypeName { get; set; }
        public string BloodGroupName { get; set; }
        public string DesignationName { get; set; }
        public string CitizenshipNo { get; set; }
        public string EmailId { get; set; }
        
        //Address
        public string LocalAddress { get; set; }
        public string LocalAddressContactNo { get; set; }
        public string LocalAddressMobileNo { get; set; }
        public string PermanentAddress { get; set; }
        public string PermanentAddressContactNo { get; set; }
        public string PermanentAddressMobileNo { get; set; }
        public string EmergencyAddress { get; set; }
        public string EmergencyAddressContactNo { get; set; }
        public string EmergencyAddressMobileNo { get; set; }

        //Job Specific
        public bool JobDetailsExist { get; set; }
        public IList<string> JobDepartments { get; set; }
        public string JobDesignationCode { get; set; }
        public string JobDescription { get; set; }
        public string OfficeJoinDate { get; set; }
        public int? ExperienceYearsOnOfficeJoin { get; set; }
        public int? ExperienceMonthsOnOfficeJoin { get; set; }
        public string PerformanceInThreeMonths { get; set; }
        public bool IsAbsent { get; set; }

        //Account Specific
        public bool AccountDetailsExist { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string BankAccountNo { get; set; }
        public decimal SalaryWithTax { get; set; }
        public IList<string> Allowances { get; set; }

        //Social Accounts
        public string GooglePlusLink { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }

    }
}
