namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedratingstoint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AssignStakeholderPersistenceEntities", "PowerOnProject", c => c.Int(nullable: false));
            AlterColumn("dbo.AssignStakeholderPersistenceEntities", "InterestOnProject", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AssignStakeholderPersistenceEntities", "InterestOnProject", c => c.String());
            AlterColumn("dbo.AssignStakeholderPersistenceEntities", "PowerOnProject", c => c.String());
        }
    }
}
