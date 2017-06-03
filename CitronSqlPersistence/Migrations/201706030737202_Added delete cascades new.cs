namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addeddeletecascadesnew : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID", "dbo.AllowancePersistenceEntities");
            DropForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID", "dbo.JobDepartmentPersistenceEntities");
            DropForeignKey("dbo.ProjectAssignedEmployeesPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropForeignKey("dbo.ProjectAssignedEmployeesPersistenceEntities", "ProjectID", "dbo.ProjectPersistenceEntities");
            DropIndex("dbo.EmployeeAllowanceDetailPersistenceEntities", new[] { "AllowanceID" });
            DropIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", new[] { "EmployeeID" });
            DropIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", new[] { "DepartmentID" });
            DropIndex("dbo.ProjectAssignedEmployeesPersistenceEntities", new[] { "EmployeeID" });
            DropIndex("dbo.ProjectAssignedEmployeesPersistenceEntities", new[] { "ProjectID" });
            AlterColumn("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID", c => c.Int(nullable: false));
            AlterColumn("dbo.ProjectAssignedEmployeesPersistenceEntities", "EmployeeID", c => c.Int(nullable: false));
            AlterColumn("dbo.ProjectAssignedEmployeesPersistenceEntities", "ProjectID", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeePersistenceEntities", "MaritalStatus");
            CreateIndex("dbo.EmployeePersistenceEntities", "PersonalityType");
            CreateIndex("dbo.EmployeePersistenceEntities", "BloodGroup");
            CreateIndex("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID");
            CreateIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID");
            CreateIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID");
            CreateIndex("dbo.ProjectAssignedEmployeesPersistenceEntities", "EmployeeID");
            CreateIndex("dbo.ProjectAssignedEmployeesPersistenceEntities", "ProjectID");
            AddForeignKey("dbo.EmployeePersistenceEntities", "BloodGroup", "dbo.BloodGroupPersistenceEntities", "ID");
            AddForeignKey("dbo.EmployeePersistenceEntities", "MaritalStatus", "dbo.MaritalStatusPersistenceEntities", "ID");
            AddForeignKey("dbo.EmployeePersistenceEntities", "PersonalityType", "dbo.PersonalityTypePersistenceEntities", "ID");
            AddForeignKey("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID", "dbo.AllowancePersistenceEntities", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID", "dbo.JobDepartmentPersistenceEntities", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProjectAssignedEmployeesPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProjectAssignedEmployeesPersistenceEntities", "ProjectID", "dbo.ProjectPersistenceEntities", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectAssignedEmployeesPersistenceEntities", "ProjectID", "dbo.ProjectPersistenceEntities");
            DropForeignKey("dbo.ProjectAssignedEmployeesPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID", "dbo.JobDepartmentPersistenceEntities");
            DropForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities");
            DropForeignKey("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID", "dbo.AllowancePersistenceEntities");
            DropForeignKey("dbo.EmployeePersistenceEntities", "PersonalityType", "dbo.PersonalityTypePersistenceEntities");
            DropForeignKey("dbo.EmployeePersistenceEntities", "MaritalStatus", "dbo.MaritalStatusPersistenceEntities");
            DropForeignKey("dbo.EmployeePersistenceEntities", "BloodGroup", "dbo.BloodGroupPersistenceEntities");
            DropIndex("dbo.ProjectAssignedEmployeesPersistenceEntities", new[] { "ProjectID" });
            DropIndex("dbo.ProjectAssignedEmployeesPersistenceEntities", new[] { "EmployeeID" });
            DropIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", new[] { "DepartmentID" });
            DropIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", new[] { "EmployeeID" });
            DropIndex("dbo.EmployeeAllowanceDetailPersistenceEntities", new[] { "AllowanceID" });
            DropIndex("dbo.EmployeePersistenceEntities", new[] { "BloodGroup" });
            DropIndex("dbo.EmployeePersistenceEntities", new[] { "PersonalityType" });
            DropIndex("dbo.EmployeePersistenceEntities", new[] { "MaritalStatus" });
            AlterColumn("dbo.ProjectAssignedEmployeesPersistenceEntities", "ProjectID", c => c.Int());
            AlterColumn("dbo.ProjectAssignedEmployeesPersistenceEntities", "EmployeeID", c => c.Int());
            AlterColumn("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID", c => c.Int());
            AlterColumn("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID", c => c.Int());
            AlterColumn("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID", c => c.Int());
            CreateIndex("dbo.ProjectAssignedEmployeesPersistenceEntities", "ProjectID");
            CreateIndex("dbo.ProjectAssignedEmployeesPersistenceEntities", "EmployeeID");
            CreateIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID");
            CreateIndex("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID");
            CreateIndex("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID");
            AddForeignKey("dbo.ProjectAssignedEmployeesPersistenceEntities", "ProjectID", "dbo.ProjectPersistenceEntities", "ID");
            AddForeignKey("dbo.ProjectAssignedEmployeesPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities", "ID");
            AddForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "DepartmentID", "dbo.JobDepartmentPersistenceEntities", "ID");
            AddForeignKey("dbo.EmployeeJobDepartmentDetailPersistenceEntities", "EmployeeID", "dbo.EmployeePersistenceEntities", "ID");
            AddForeignKey("dbo.EmployeeAllowanceDetailPersistenceEntities", "AllowanceID", "dbo.AllowancePersistenceEntities", "ID");
        }
    }
}
