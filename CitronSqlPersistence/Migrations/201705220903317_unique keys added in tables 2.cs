namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniquekeysaddedintables2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AllowancePersistenceEntities", "Code", c => c.String(maxLength: 10));
            AlterColumn("dbo.BloodGroupPersistenceEntities", "Code", c => c.String(maxLength: 10));
            AlterColumn("dbo.EmployeePersistenceEntities", "Code", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.EmployeePersistenceEntities", "EmailId", c => c.String(maxLength: 200));
            AlterColumn("dbo.JobDepartmentPersistenceEntities", "Code", c => c.String(maxLength: 10));
            AlterColumn("dbo.JobDesignationPersistenceEntities", "Code", c => c.String(maxLength: 10));
            AlterColumn("dbo.MaritalStatusPersistenceEntities", "Code", c => c.String(maxLength: 10));
            AlterColumn("dbo.PersonalityTypePersistenceEntities", "Code", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonalityTypePersistenceEntities", "Code", c => c.String());
            AlterColumn("dbo.MaritalStatusPersistenceEntities", "Code", c => c.String());
            AlterColumn("dbo.JobDesignationPersistenceEntities", "Code", c => c.String());
            AlterColumn("dbo.JobDepartmentPersistenceEntities", "Code", c => c.String());
            AlterColumn("dbo.EmployeePersistenceEntities", "EmailId", c => c.String());
            AlterColumn("dbo.EmployeePersistenceEntities", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.BloodGroupPersistenceEntities", "Code", c => c.String());
            AlterColumn("dbo.AllowancePersistenceEntities", "Code", c => c.String());
        }
    }
}
