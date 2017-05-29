﻿using CitronSqlPersistence.ConfigurationPersistenceEntities;
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
        public DbSet<AllowancePersistenceEntity> AllowancePersistenceEntities { get; set; }
        public DbSet<BloodGroupPersistenceEntity> BloodGroupPersistenceEntities { get; set; }
        public DbSet<JobDepartmentPersistenceEntity> JobDepartmentPersistenceEntities { get; set; }
        public DbSet<JobDesignationPersistenceEntity> JobDesignationPersistenceEntities { get; set; }
        public DbSet<MaritalStatusPersistenceEntity> MaritalStatusPersistenceEntities { get; set; }
        public DbSet<PersonalityTypePersistenceEntity> PersonalityTypePersistenceEntities { get; set; }

        //Business tables
        public DbSet<EmployeePersistenceEntity> EmployeePersistenceEntities { get; set; }
        public DbSet<EmployeeJobHistoryPersistenceEntity> EmployeeJobHistoryPersistenceEntities { get; set; }
        public DbSet<EmployeeJobDetailPersistenceEntity> EmployeeJobDetailPersistenceEntities { get; set; }
        public DbSet<EmployeeJobDepartmentDetailPersistenceEntity> EmployeeJobDepartmentDetailPersistenceEntities { get; set; }
        public DbSet<EmployeeAccountDetailPersistenceEntity> EmployeeAccountDetailPersistenceEntities { get; set; }
        public DbSet<EmployeeAllowanceDetailPersistenceEntity> EmployeeAllowanceDetailPersistenceEntities { get; set; }
        public DbSet<EmployeeSalaryHistoryPersistenceEntity> EmployeeSalaryHistoryPersistenceEntities { get; set; }

        public DbSet<ProjectPersistenceEntity> ProjectPersistenceEntities { get; set; }
        public DbSet<ProjectTaskPersistenceEntity> ProjectTaskPersistenceEntities { get; set; }
        public SqlDbContext() : base("ConnectionString")
        {

        }
    }
}
