namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedassignedemployeesintasktable3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ProjectTaskAssignedEmployeesPersistenceEntities", name: "ProjectTaskID", newName: "ProjectTskID");
            RenameIndex(table: "dbo.ProjectTaskAssignedEmployeesPersistenceEntities", name: "IX_ProjectTaskID", newName: "IX_ProjectTskID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ProjectTaskAssignedEmployeesPersistenceEntities", name: "IX_ProjectTskID", newName: "IX_ProjectTaskID");
            RenameColumn(table: "dbo.ProjectTaskAssignedEmployeesPersistenceEntities", name: "ProjectTskID", newName: "ProjectTaskID");
        }
    }
}
