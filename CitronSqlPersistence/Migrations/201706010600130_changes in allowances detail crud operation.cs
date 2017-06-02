namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesinallowancesdetailcrudoperation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID", "dbo.AllowancePersistenceEntities");
            DropIndex("dbo.EmployeeAllowanceDetailPersistenceEntities", new[] { "AllowanceID" });
            AlterColumn("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID", c => c.Int());
            CreateIndex("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID");
            AddForeignKey("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID", "dbo.AllowancePersistenceEntities", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID", "dbo.AllowancePersistenceEntities");
            DropIndex("dbo.EmployeeAllowanceDetailPersistenceEntities", new[] { "AllowanceID" });
            AlterColumn("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID");
            AddForeignKey("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID", "dbo.AllowancePersistenceEntities", "ID", cascadeDelete: true);
        }
    }
}
