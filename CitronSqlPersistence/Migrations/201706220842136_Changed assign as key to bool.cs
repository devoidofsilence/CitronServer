namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changedassignaskeytobool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AssignStakeholderPersistenceEntities", "AssignedAsKey", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AssignStakeholderPersistenceEntities", "AssignedAsKey", c => c.String());
        }
    }
}
