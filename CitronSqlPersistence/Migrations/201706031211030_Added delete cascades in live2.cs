namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addeddeletecascadesinlive2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectTaskPersistenceEntities", "ResponsibleEmployeeID", "dbo.EmployeePersistenceEntities");
            AddForeignKey("dbo.ProjectTaskPersistenceEntities", "ResponsibleEmployeeID", "dbo.EmployeePersistenceEntities", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectTaskPersistenceEntities", "ResponsibleEmployeeID", "dbo.EmployeePersistenceEntities");
            AddForeignKey("dbo.ProjectTaskPersistenceEntities", "ResponsibleEmployeeID", "dbo.EmployeePersistenceEntities", "ID");
        }
    }
}
