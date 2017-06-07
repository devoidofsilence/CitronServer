namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedtableforassigneesofTasks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectTaskPersistenceEntities", "ParentProjectTaskID", "dbo.ProjectTaskPersistenceEntities");
            DropIndex("dbo.ProjectTaskPersistenceEntities", new[] { "ParentProjectTaskID" });
            CreateTable(
                "dbo.ProjectTaskAssignedEmployeesPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        ProjectTaskID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeePersistenceEntities", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectTaskAssignedEmployeesPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropIndex("dbo.ProjectTaskAssignedEmployeesPersistenceEntities", new[] { "EmployeeID" });
            DropTable("dbo.ProjectTaskAssignedEmployeesPersistenceEntities");
            CreateIndex("dbo.ProjectTaskPersistenceEntities", "ParentProjectTaskID");
            AddForeignKey("dbo.ProjectTaskPersistenceEntities", "ParentProjectTaskID", "dbo.ProjectTaskPersistenceEntities", "ID");
        }
    }
}
