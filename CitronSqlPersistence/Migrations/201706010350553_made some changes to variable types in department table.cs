namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madesomechangestovariabletypesindepartmenttable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID", "dbo.JobDepartmentPersistenceEntities");
            DropIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", new[] { "DepartmentID" });
            AlterColumn("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID", c => c.Int());
            CreateIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID");
            AddForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID", "dbo.JobDepartmentPersistenceEntities", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID", "dbo.JobDepartmentPersistenceEntities");
            DropIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", new[] { "DepartmentID" });
            AlterColumn("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID");
            AddForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID", "dbo.JobDepartmentPersistenceEntities", "ID", cascadeDelete: true);
        }
    }
}
