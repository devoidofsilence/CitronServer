namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllowancePersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 10),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "dbo.BloodGroupPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 10),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Code, unique: true);
            
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeePersistenceEntities", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.EmployeePersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false),
                        Photo = c.Binary(),
                        Birthday = c.DateTime(),
                        MaritalStatus = c.Int(),
                        PersonalityType = c.Int(),
                        BloodGroup = c.Int(),
                        CitizenshipNo = c.String(),
                        EmailId = c.String(maxLength: 200),
                        LocalAddress = c.String(),
                        LocalAddressContactNo = c.String(),
                        LocalAddressMobileNo = c.String(),
                        PermanentAddress = c.String(),
                        PermanentAddressContactNo = c.String(),
                        PermanentAddressMobileNo = c.String(),
                        EmergencyAddress = c.String(),
                        EmergencyAddressContactNo = c.String(),
                        EmergencyAddressMobileNo = c.String(),
                        GooglePlusLink = c.String(),
                        FacebookLink = c.String(),
                        TwitterLink = c.String(),
                        LinkedInLink = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Code, unique: true)
                .Index(t => t.EmailId, unique: true);
            
            CreateTable(
                "dbo.EmployeeAllowanceDetailPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        AllowanceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AllowancePersistenceEntities", t => t.AllowanceID, cascadeDelete: true)
                .ForeignKey("dbo.EmployeePersistenceEntities", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.AllowanceID);
            
            CreateTable(
                "dbo.EmployeeJobDepartmentDetailPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeePersistenceEntities", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.JobDepartmentPersistenceEntities", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.JobDepartmentPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 10),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Code, unique: true);
            
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeePersistenceEntities", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.JobDesignationPersistenceEntities", t => t.DesignationID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.DesignationID);
            
            CreateTable(
                "dbo.JobDesignationPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 10),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "dbo.EmployeeJobHistoryPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        DesignationID = c.Int(nullable: false),
                        Description = c.String(),
                        AssignedFrom = c.DateTime(nullable: false),
                        AssignedTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeePersistenceEntities", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.JobDepartmentPersistenceEntities", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.JobDesignationPersistenceEntities", t => t.DesignationID, cascadeDelete: true)
                .Index(t => t.EmployeeID)
                .Index(t => t.DepartmentID)
                .Index(t => t.DesignationID);
            
            CreateTable(
                "dbo.EmployeeSalaryHistoryPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        SalaryWithTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        From = c.DateTime(),
                        To = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.EmployeePersistenceEntities", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.MaritalStatusPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 10),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "dbo.PersonalityTypePersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 10),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Code, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeSalaryHistoryPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropForeignKey("dbo.EmployeeJobHistoryPersistenceEntities", "DesignationID", "dbo.JobDesignationPersistenceEntities");
            DropForeignKey("dbo.EmployeeJobHistoryPersistenceEntities", "DepartmentID", "dbo.JobDepartmentPersistenceEntities");
            DropForeignKey("dbo.EmployeeJobHistoryPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropForeignKey("dbo.EmployeeJobDetailPersistenceEntities", "DesignationID", "dbo.JobDesignationPersistenceEntities");
            DropForeignKey("dbo.EmployeeJobDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID", "dbo.JobDepartmentPersistenceEntities");
            DropForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropForeignKey("dbo.EmployeeAllowanceDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropForeignKey("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID", "dbo.AllowancePersistenceEntities");
            DropForeignKey("dbo.EmployeeAccountDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropIndex("dbo.PersonalityTypePersistenceEntities", new[] { "Code" });
            DropIndex("dbo.MaritalStatusPersistenceEntities", new[] { "Code" });
            DropIndex("dbo.EmployeeSalaryHistoryPersistenceEntities", new[] { "EmployeeID" });
            DropIndex("dbo.EmployeeJobHistoryPersistenceEntities", new[] { "DesignationID" });
            DropIndex("dbo.EmployeeJobHistoryPersistenceEntities", new[] { "DepartmentID" });
            DropIndex("dbo.EmployeeJobHistoryPersistenceEntities", new[] { "EmployeeID" });
            DropIndex("dbo.JobDesignationPersistenceEntities", new[] { "Code" });
            DropIndex("dbo.EmployeeJobDetailPersistenceEntities", new[] { "DesignationID" });
            DropIndex("dbo.EmployeeJobDetailPersistenceEntities", new[] { "EmployeeID" });
            DropIndex("dbo.JobDepartmentPersistenceEntities", new[] { "Code" });
            DropIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", new[] { "DepartmentID" });
            DropIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", new[] { "EmployeeID" });
            DropIndex("dbo.EmployeeAllowanceDetailPersistenceEntities", new[] { "AllowanceID" });
            DropIndex("dbo.EmployeeAllowanceDetailPersistenceEntities", new[] { "EmployeeID" });
            DropIndex("dbo.EmployeePersistenceEntities", new[] { "EmailId" });
            DropIndex("dbo.EmployeePersistenceEntities", new[] { "Code" });
            DropIndex("dbo.EmployeeAccountDetailPersistenceEntities", new[] { "EmployeeID" });
            DropIndex("dbo.BloodGroupPersistenceEntities", new[] { "Code" });
            DropIndex("dbo.AllowancePersistenceEntities", new[] { "Code" });
            DropTable("dbo.PersonalityTypePersistenceEntities");
            DropTable("dbo.MaritalStatusPersistenceEntities");
            DropTable("dbo.EmployeeSalaryHistoryPersistenceEntities");
            DropTable("dbo.EmployeeJobHistoryPersistenceEntities");
            DropTable("dbo.JobDesignationPersistenceEntities");
            DropTable("dbo.EmployeeJobDetailPersistenceEntities");
            DropTable("dbo.JobDepartmentPersistenceEntities");
            DropTable("dbo.EmployeeJobDepartmentDetailPersistenceEntities");
            DropTable("dbo.EmployeeAllowanceDetailPersistenceEntities");
            DropTable("dbo.EmployeePersistenceEntities");
            DropTable("dbo.EmployeeAccountDetailPersistenceEntities");
            DropTable("dbo.BloodGroupPersistenceEntities");
            DropTable("dbo.AllowancePersistenceEntities");
        }
    }
}
