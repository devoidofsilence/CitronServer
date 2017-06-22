namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedtableforAssigningStakeholder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignStakeholderPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProjectCode = c.String(nullable: false),
                        StakeholderCode = c.String(nullable: false),
                        PowerOnProject = c.String(),
                        InterestOnProject = c.String(),
                        AssignedAsKey = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AssignStakeholderPersistenceEntities");
        }
    }
}
