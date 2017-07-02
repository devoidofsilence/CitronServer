namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changesindb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssignStakeholderPersistenceEntities", "ProjectId", c => c.Int(nullable: false));
            AddColumn("dbo.AssignStakeholderPersistenceEntities", "StakeholderId", c => c.Int(nullable: false));
            DropColumn("dbo.AssignStakeholderPersistenceEntities", "ProjectCode");
            DropColumn("dbo.AssignStakeholderPersistenceEntities", "StakeholderCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssignStakeholderPersistenceEntities", "StakeholderCode", c => c.String(nullable: false));
            AddColumn("dbo.AssignStakeholderPersistenceEntities", "ProjectCode", c => c.String(nullable: false));
            DropColumn("dbo.AssignStakeholderPersistenceEntities", "StakeholderId");
            DropColumn("dbo.AssignStakeholderPersistenceEntities", "ProjectId");
        }
    }
}
