namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtablesadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeAccountDetailPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        BankName = c.String(),
                        BankBranch = c.String(),
                        BankAccountNo = c.String(),
                        SalaryWithTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmployeeJobDepartmentDetailPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmployeeJobDetailPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        DesignationID = c.Int(nullable: false),
                        Description = c.String(),
                        OfficeJoinDate = c.DateTime(),
                        ExperienceYearsOnOfficeJoin = c.Int(),
                        ExperienceMonthsOnOfficeJoin = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmployeeSalaryHistoryPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        Salary = c.Int(nullable: false),
                        From = c.DateTime(),
                        To = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropColumn("dbo.EmployeePersistenceEntities", "BankName");
            DropColumn("dbo.EmployeePersistenceEntities", "BankBranch");
            DropColumn("dbo.EmployeePersistenceEntities", "BankAccountNo");
            DropColumn("dbo.EmployeePersistenceEntities", "SalaryWithTax");
            DropColumn("dbo.EmployeePersistenceEntities", "JobDesignation");
            DropColumn("dbo.EmployeePersistenceEntities", "JobDescription");
            DropColumn("dbo.EmployeePersistenceEntities", "OfficeJoinDate");
            DropColumn("dbo.EmployeePersistenceEntities", "ExperienceYearsOnOfficeJoin");
            DropColumn("dbo.EmployeePersistenceEntities", "ExperienceMonthsOnOfficeJoin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeePersistenceEntities", "ExperienceMonthsOnOfficeJoin", c => c.Int());
            AddColumn("dbo.EmployeePersistenceEntities", "ExperienceYearsOnOfficeJoin", c => c.Int());
            AddColumn("dbo.EmployeePersistenceEntities", "OfficeJoinDate", c => c.DateTime());
            AddColumn("dbo.EmployeePersistenceEntities", "JobDescription", c => c.String());
            AddColumn("dbo.EmployeePersistenceEntities", "JobDesignation", c => c.Int());
            AddColumn("dbo.EmployeePersistenceEntities", "SalaryWithTax", c => c.String());
            AddColumn("dbo.EmployeePersistenceEntities", "BankAccountNo", c => c.String());
            AddColumn("dbo.EmployeePersistenceEntities", "BankBranch", c => c.String());
            AddColumn("dbo.EmployeePersistenceEntities", "BankName", c => c.String());
            DropTable("dbo.EmployeeSalaryHistoryPersistenceEntities");
            DropTable("dbo.EmployeeJobDetailPersistenceEntities");
            DropTable("dbo.EmployeeJobDepartmentDetailPersistenceEntities");
            DropTable("dbo.EmployeeAccountDetailPersistenceEntities");
        }
    }
}
