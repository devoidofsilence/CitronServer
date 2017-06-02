namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madesomechangestovariabletypes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeJobDetailPersistenceEntities", "DesignationID", "dbo.JobDesignationPersistenceEntities");
            DropIndex("dbo.EmployeeJobDetailPersistenceEntities", new[] { "DesignationID" });
            AlterColumn("dbo.EmployeeJobDetailPersistenceEntities", "DesignationID", c => c.Int());
            CreateIndex("dbo.EmployeeJobDetailPersistenceEntities", "DesignationID");
            AddForeignKey("dbo.EmployeeJobDetailPersistenceEntities", "DesignationID", "dbo.JobDesignationPersistenceEntities", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeJobDetailPersistenceEntities", "DesignationID", "dbo.JobDesignationPersistenceEntities");
            DropIndex("dbo.EmployeeJobDetailPersistenceEntities", new[] { "DesignationID" });
            AlterColumn("dbo.EmployeeJobDetailPersistenceEntities", "DesignationID", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeJobDetailPersistenceEntities", "DesignationID");
            AddForeignKey("dbo.EmployeeJobDetailPersistenceEntities", "DesignationID", "dbo.JobDesignationPersistenceEntities", "ID", cascadeDelete: true);
        }
    }
}
