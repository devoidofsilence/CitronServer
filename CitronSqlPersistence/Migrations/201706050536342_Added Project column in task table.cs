namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProjectcolumnintasktable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectTaskPersistenceEntities", "ProjectID", c => c.Int());
            CreateIndex("dbo.ProjectTaskPersistenceEntities", "ProjectID");
            AddForeignKey("dbo.ProjectTaskPersistenceEntities", "ProjectID", "dbo.ProjectPersistenceEntities", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectTaskPersistenceEntities", "ProjectID", "dbo.ProjectPersistenceEntities");
            DropIndex("dbo.ProjectTaskPersistenceEntities", new[] { "ProjectID" });
            DropColumn("dbo.ProjectTaskPersistenceEntities", "ProjectID");
        }
    }
}
