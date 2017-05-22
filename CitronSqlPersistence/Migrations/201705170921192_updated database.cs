namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllowancePersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BloodGroupPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.JobDepartmentPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.JobDesignationPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MaritalStatusPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PersonalityTypePersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.EmployeeJobHistoryPersistenceEntities", "AssignedFrom", c => c.DateTime(nullable: false));
            AddColumn("dbo.EmployeeJobHistoryPersistenceEntities", "AssignedTo", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeJobHistoryPersistenceEntities", "AssignedTo");
            DropColumn("dbo.EmployeeJobHistoryPersistenceEntities", "AssignedFrom");
            DropTable("dbo.PersonalityTypePersistenceEntities");
            DropTable("dbo.MaritalStatusPersistenceEntities");
            DropTable("dbo.JobDesignationPersistenceEntities");
            DropTable("dbo.JobDepartmentPersistenceEntities");
            DropTable("dbo.BloodGroupPersistenceEntities");
            DropTable("dbo.AllowancePersistenceEntities");
        }
    }
}
