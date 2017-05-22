namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateddatabasewithcorrentedfields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeePersistenceEntities", "Birthday", c => c.DateTime());
            AlterColumn("dbo.EmployeePersistenceEntities", "OfficeJoinDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeePersistenceEntities", "OfficeJoinDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeePersistenceEntities", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
