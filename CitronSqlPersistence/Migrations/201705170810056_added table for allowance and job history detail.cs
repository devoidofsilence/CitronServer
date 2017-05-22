namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtableforallowanceandjobhistorydetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeAllowanceDetailPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        AllowanceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EmployeeJobHistoryPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmployeeID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        DesignationID = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeJobHistoryPersistenceEntities");
            DropTable("dbo.EmployeeAllowanceDetailPersistenceEntities");
        }
    }
}
