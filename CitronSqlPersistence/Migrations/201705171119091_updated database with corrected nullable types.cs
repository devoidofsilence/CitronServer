namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddatabasewithcorrectednullabletypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeePersistenceEntities", "MaritalStatus", c => c.Int());
            AlterColumn("dbo.EmployeePersistenceEntities", "PersonalityType", c => c.Int());
            AlterColumn("dbo.EmployeePersistenceEntities", "BloodGroup", c => c.Int());
            AlterColumn("dbo.EmployeePersistenceEntities", "JobDesignation", c => c.Int());
            AlterColumn("dbo.EmployeePersistenceEntities", "ExperienceYearsOnOfficeJoin", c => c.Int());
            AlterColumn("dbo.EmployeePersistenceEntities", "ExperienceMonthsOnOfficeJoin", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeePersistenceEntities", "ExperienceMonthsOnOfficeJoin", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeePersistenceEntities", "ExperienceYearsOnOfficeJoin", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeePersistenceEntities", "JobDesignation", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeePersistenceEntities", "BloodGroup", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeePersistenceEntities", "PersonalityType", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeePersistenceEntities", "MaritalStatus", c => c.Int(nullable: false));
        }
    }
}
