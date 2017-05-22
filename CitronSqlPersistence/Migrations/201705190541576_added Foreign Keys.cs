namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedForeignKeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeSalaryHistoryPersistenceEntities", "SalaryWithTax", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.EmployeeAccountDetailPersistenceEntities", "EmployeeID");
            CreateIndex("dbo.EmployeeAllowanceDetailPersistenceEntities", "EmployeeID");
            CreateIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID");
            CreateIndex("dbo.EmployeeJobDetailPersistenceEntities", "EmployeeID");
            CreateIndex("dbo.EmployeeJobHistoryPersistenceEntities", "EmployeeID");
            CreateIndex("dbo.EmployeeSalaryHistoryPersistenceEntities", "EmployeeID");
            AddForeignKey("dbo.EmployeeAccountDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeAllowanceDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeJobDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeJobHistoryPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeSalaryHistoryPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities", "ID", cascadeDelete: true);
            DropColumn("dbo.EmployeeSalaryHistoryPersistenceEntities", "Salary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeSalaryHistoryPersistenceEntities", "Salary", c => c.Int(nullable: false));
            DropForeignKey("dbo.EmployeeSalaryHistoryPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropForeignKey("dbo.EmployeeJobHistoryPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropForeignKey("dbo.EmployeeJobDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropForeignKey("dbo.EmployeeAllowanceDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropForeignKey("dbo.EmployeeAccountDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropIndex("dbo.EmployeeSalaryHistoryPersistenceEntities", new[] { "EmployeeID" });
            DropIndex("dbo.EmployeeJobHistoryPersistenceEntities", new[] { "EmployeeID" });
            DropIndex("dbo.EmployeeJobDetailPersistenceEntities", new[] { "EmployeeID" });
            DropIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", new[] { "EmployeeID" });
            DropIndex("dbo.EmployeeAllowanceDetailPersistenceEntities", new[] { "EmployeeID" });
            DropIndex("dbo.EmployeeAccountDetailPersistenceEntities", new[] { "EmployeeID" });
            DropColumn("dbo.EmployeeSalaryHistoryPersistenceEntities", "SalaryWithTax");
        }
    }
}
