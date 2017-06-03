namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Somechangestodatabaseskeys : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.EmployeePersistenceEntities", new[] { "EmailId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.EmployeePersistenceEntities", "EmailId", unique: true);
        }
    }
}
