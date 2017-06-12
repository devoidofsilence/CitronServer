namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Codefieldremovedfromprojectchartertable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ProjectCharterPersistenceEntities", new[] { "Code" });
            DropColumn("dbo.ProjectCharterPersistenceEntities", "Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectCharterPersistenceEntities", "Code", c => c.String(nullable: false, maxLength: 10));
            CreateIndex("dbo.ProjectCharterPersistenceEntities", "Code", unique: true);
        }
    }
}
