namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedassignedemployeesintasktable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectTaskAssignedEmployeesPersistenceEntities", "projectTaskPersistenceEntity_ID", c => c.Int());
            CreateIndex("dbo.ProjectTaskAssignedEmployeesPersistenceEntities", "projectTaskPersistenceEntity_ID");
            AddForeignKey("dbo.ProjectTaskAssignedEmployeesPersistenceEntities", "projectTaskPersistenceEntity_ID", "dbo.ProjectTaskPersistenceEntities", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectTaskAssignedEmployeesPersistenceEntities", "projectTaskPersistenceEntity_ID", "dbo.ProjectTaskPersistenceEntities");
            DropIndex("dbo.ProjectTaskAssignedEmployeesPersistenceEntities", new[] { "projectTaskPersistenceEntity_ID" });
            DropColumn("dbo.ProjectTaskAssignedEmployeesPersistenceEntities", "projectTaskPersistenceEntity_ID");
        }
    }
}
