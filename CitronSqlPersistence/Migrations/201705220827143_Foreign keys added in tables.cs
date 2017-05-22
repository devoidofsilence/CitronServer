namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Foreignkeysaddedintables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeePersistenceEntities", "LocalAddressMobileNo", c => c.String());
            AddColumn("dbo.EmployeePersistenceEntities", "PermanentAddressMobileNo", c => c.String());
            AddColumn("dbo.EmployeePersistenceEntities", "EmergencyAddressMobileNo", c => c.String());
            CreateIndex("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID");
            CreateIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID");
            CreateIndex("dbo.EmployeeJobDetailPersistenceEntities", "DesignationID");
            CreateIndex("dbo.EmployeeJobHistoryPersistenceEntities", "DepartmentID");
            CreateIndex("dbo.EmployeeJobHistoryPersistenceEntities", "DesignationID");
            AddForeignKey("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID", "dbo.AllowancePersistenceEntities", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID", "dbo.JobDepartmentPersistenceEntities", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeJobDetailPersistenceEntities", "DesignationID", "dbo.JobDesignationPersistenceEntities", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeJobHistoryPersistenceEntities", "DepartmentID", "dbo.JobDepartmentPersistenceEntities", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeJobHistoryPersistenceEntities", "DesignationID", "dbo.JobDesignationPersistenceEntities", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeJobHistoryPersistenceEntities", "DesignationID", "dbo.JobDesignationPersistenceEntities");
            DropForeignKey("dbo.EmployeeJobHistoryPersistenceEntities", "DepartmentID", "dbo.JobDepartmentPersistenceEntities");
            DropForeignKey("dbo.EmployeeJobDetailPersistenceEntities", "DesignationID", "dbo.JobDesignationPersistenceEntities");
            DropForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID", "dbo.JobDepartmentPersistenceEntities");
            DropForeignKey("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID", "dbo.AllowancePersistenceEntities");
            DropIndex("dbo.EmployeeJobHistoryPersistenceEntities", new[] { "DesignationID" });
            DropIndex("dbo.EmployeeJobHistoryPersistenceEntities", new[] { "DepartmentID" });
            DropIndex("dbo.EmployeeJobDetailPersistenceEntities", new[] { "DesignationID" });
            DropIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", new[] { "DepartmentID" });
            DropIndex("dbo.EmployeeAllowanceDetailPersistenceEntities", new[] { "AllowanceID" });
            DropColumn("dbo.EmployeePersistenceEntities", "EmergencyAddressMobileNo");
            DropColumn("dbo.EmployeePersistenceEntities", "PermanentAddressMobileNo");
            DropColumn("dbo.EmployeePersistenceEntities", "LocalAddressMobileNo");
        }
    }
}
