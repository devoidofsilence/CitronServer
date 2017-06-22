namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedtablesforstakeholders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StakeholderPersistenceEntities", "Mobile", c => c.String());
            AddColumn("dbo.StakeholderPersistenceEntities", "Fax", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StakeholderPersistenceEntities", "Fax");
            DropColumn("dbo.StakeholderPersistenceEntities", "Mobile");
        }
    }
}
