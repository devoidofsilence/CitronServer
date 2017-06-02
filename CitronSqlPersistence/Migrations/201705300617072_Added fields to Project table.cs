namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedfieldstoProjecttable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectPersistenceEntities", "Status", c => c.String());
            AddColumn("dbo.ProjectPersistenceEntities", "PercentageCompleted", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectPersistenceEntities", "PercentageCompleted");
            DropColumn("dbo.ProjectPersistenceEntities", "Status");
        }
    }
}
