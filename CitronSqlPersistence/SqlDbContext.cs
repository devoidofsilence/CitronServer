using CitronSqlPersistence.ConfigurationPersistenceEntities;
using CitronSqlPersistence.PersistenceEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitronSqlPersistence
{
    public class SqlDbContext : DbContext
    {
        //Configuration Tables
        public DbSet<AllowancePersistenceEntity> allowancePersistenceEntities { get; set; }
        public DbSet<BloodGroupPersistenceEntity> bloodGroupPersistenceEntities { get; set; }
        public DbSet<JobDepartmentPersistenceEntity> jobDepartmentPersistenceEntities { get; set; }
        public DbSet<JobDesignationPersistenceEntity> jobDesignationPersistenceEntities { get; set; }
        public DbSet<MaritalStatusPersistenceEntity> maritalStatusPersistenceEntities { get; set; }
        public DbSet<PersonalityTypePersistenceEntity> personalityTypePersistenceEntities { get; set; }

        //Business tables
        public DbSet<EmployeePersistenceEntity> EmployeePersistenceEntities { get; set; }
        public DbSet<EmployeeJobHistoryPersistenceEntity> EmployeeJobHistoryPersistenceEntities { get; set; }
        public DbSet<EmployeeJobDetailPersistenceEntity> EmployeeJobDetailPersistenceEntities { get; set; }
        public DbSet<EmployeeJobDepartmentDetailPersistenceEntity> EmployeeJobDepartmentDetailPersistenceEntities { get; set; }
        public DbSet<EmployeeAccountDetailPersistenceEntity> EmployeeAccountDetailPersistenceEntities { get; set; }
        public DbSet<EmployeeAllowanceDetailPersistenceEntity> EmployeeAllowanceDetailPersistenceEntities { get; set; }
        public DbSet<EmployeeSalaryHistoryPersistenceEntity> EmployeeSalaryHistoryPersistenceEntities { get; set; }
        public SqlDbContext() : base("ConnectionString")
        {

        }
    }
}
