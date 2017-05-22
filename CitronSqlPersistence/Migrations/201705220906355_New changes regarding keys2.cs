namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newchangesregardingkeys2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AllowancePersistenceEntities", "Code", unique: true);
            CreateIndex("dbo.BloodGroupPersistenceEntities", "Code", unique: true);
            CreateIndex("dbo.EmployeePersistenceEntities", "Code", unique: true);
            CreateIndex("dbo.EmployeePersistenceEntities", "EmailId", unique: true);
            CreateIndex("dbo.JobDepartmentPersistenceEntities", "Code", unique: true);
            CreateIndex("dbo.JobDesignationPersistenceEntities", "Code", unique: true);
            CreateIndex("dbo.MaritalStatusPersistenceEntities", "Code", unique: true);
            CreateIndex("dbo.PersonalityTypePersistenceEntities", "Code", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.PersonalityTypePersistenceEntities", new[] { "Code" });
            DropIndex("dbo.MaritalStatusPersistenceEntities", new[] { "Code" });
            DropIndex("dbo.JobDesignationPersistenceEntities", new[] { "Code" });
            DropIndex("dbo.JobDepartmentPersistenceEntities", new[] { "Code" });
            DropIndex("dbo.EmployeePersistenceEntities", new[] { "EmailId" });
            DropIndex("dbo.EmployeePersistenceEntities", new[] { "Code" });
            DropIndex("dbo.BloodGroupPersistenceEntities", new[] { "Code" });
            DropIndex("dbo.AllowancePersistenceEntities", new[] { "Code" });
        }
    }
}
