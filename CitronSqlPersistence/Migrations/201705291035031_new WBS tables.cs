namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newWBStables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "dbo.ProjectTaskPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        ParentProjectTaskID = c.Int(),
                        ResponsibleEmployeeID = c.Int(),
                        OptimisticTime = c.Int(nullable: false),
                        PessimisticTime = c.Int(nullable: false),
                        NormalTime = c.Int(nullable: false),
                        ExpectedTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProjectTaskPersistenceEntities", t => t.ParentProjectTaskID)
                .ForeignKey("dbo.EmployeePersistenceEntities", t => t.ResponsibleEmployeeID)
                .Index(t => t.Code, unique: true)
                .Index(t => t.ParentProjectTaskID)
                .Index(t => t.ResponsibleEmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectTaskPersistenceEntities", "ResponsibleEmployeeID", "dbo.EmployeePersistenceEntities");
            DropForeignKey("dbo.ProjectTaskPersistenceEntities", "ParentProjectTaskID", "dbo.ProjectTaskPersistenceEntities");
            DropIndex("dbo.ProjectTaskPersistenceEntities", new[] { "ResponsibleEmployeeID" });
            DropIndex("dbo.ProjectTaskPersistenceEntities", new[] { "ParentProjectTaskID" });
            DropIndex("dbo.ProjectTaskPersistenceEntities", new[] { "Code" });
            DropIndex("dbo.ProjectPersistenceEntities", new[] { "Code" });
            DropTable("dbo.ProjectTaskPersistenceEntities");
            DropTable("dbo.ProjectPersistenceEntities");
        }
    }
}
