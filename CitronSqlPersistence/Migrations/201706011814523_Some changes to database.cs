namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Somechangestodatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", new[] { "EmployeeID" });
            CreateTable(
                "dbo.ProjectAssignedEmployeesPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(),
                        ProjectID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeePersistenceEntities", t => t.EmployeeID)
                .ForeignKey("dbo.ProjectPersistenceEntities", t => t.ProjectID)
                .Index(t => t.EmployeeID)
                .Index(t => t.ProjectID);
            
            AlterColumn("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID", c => c.Int());
            CreateIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID");
            AddForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropForeignKey("dbo.ProjectAssignedEmployeesPersistenceEntities", "ProjectID", "dbo.ProjectPersistenceEntities");
            DropForeignKey("dbo.ProjectAssignedEmployeesPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropIndex("dbo.ProjectAssignedEmployeesPersistenceEntities", new[] { "ProjectID" });
            DropIndex("dbo.ProjectAssignedEmployeesPersistenceEntities", new[] { "EmployeeID" });
            DropIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", new[] { "EmployeeID" });
            AlterColumn("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID", c => c.Int(nullable: false));
            DropTable("dbo.ProjectAssignedEmployeesPersistenceEntities");
            CreateIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID");
            AddForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities", "ID", cascadeDelete: true);
        }
    }
}
