namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedassignedemployeesintasktable2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProjectTaskAssignedEmployeesPersistenceEntities", new[] { "projectTaskPersistenceEntity_ID" });
            DropColumn("dbo.ProjectTaskAssignedEmployeesPersistenceEntities", "ProjectTaskID");
            RenameColumn(table: "dbo.ProjectTaskAssignedEmployeesPersistenceEntities", name: "projectTaskPersistenceEntity_ID", newName: "ProjectTaskID");
            AlterColumn("dbo.ProjectTaskAssignedEmployeesPersistenceEntities", "ProjectTaskID", c => c.Int());
            CreateIndex("dbo.ProjectTaskAssignedEmployeesPersistenceEntities", "ProjectTaskID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProjectTaskAssignedEmployeesPersistenceEntities", new[] { "ProjectTaskID" });
            AlterColumn("dbo.ProjectTaskAssignedEmployeesPersistenceEntities", "ProjectTaskID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ProjectTaskAssignedEmployeesPersistenceEntities", name: "ProjectTaskID", newName: "projectTaskPersistenceEntity_ID");
            AddColumn("dbo.ProjectTaskAssignedEmployeesPersistenceEntities", "ProjectTaskID", c => c.Int(nullable: false));
            CreateIndex("dbo.ProjectTaskAssignedEmployeesPersistenceEntities", "projectTaskPersistenceEntity_ID");
        }
    }
}
