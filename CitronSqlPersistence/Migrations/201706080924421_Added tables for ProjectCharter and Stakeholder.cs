namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedtablesforProjectCharterandStakeholder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectCharterPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 10),
                        ProjectID = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProjectCharterQuestionPersistenceEntities", t => t.QuestionID, cascadeDelete: true)
                .ForeignKey("dbo.ProjectPersistenceEntities", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.Code, unique: true)
                .Index(t => t.ProjectID)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.ProjectCharterQuestionPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 10),
                        HeaderID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProjectCharterQuestionHeaderPersistenceEntities", t => t.HeaderID, cascadeDelete: true)
                .Index(t => t.Code, unique: true)
                .Index(t => t.HeaderID);
            
            CreateTable(
                "dbo.ProjectCharterQuestionHeaderPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 10),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "dbo.StakeholderPersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        OrganizationName = c.String(),
                        JobPosition = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Code, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectCharterPersistenceEntities", "ProjectID", "dbo.ProjectPersistenceEntities");
            DropForeignKey("dbo.ProjectCharterPersistenceEntities", "QuestionID", "dbo.ProjectCharterQuestionPersistenceEntities");
            DropForeignKey("dbo.ProjectCharterQuestionPersistenceEntities", "HeaderID", "dbo.ProjectCharterQuestionHeaderPersistenceEntities");
            DropIndex("dbo.StakeholderPersistenceEntities", new[] { "Code" });
            DropIndex("dbo.ProjectCharterQuestionHeaderPersistenceEntities", new[] { "Code" });
            DropIndex("dbo.ProjectCharterQuestionPersistenceEntities", new[] { "HeaderID" });
            DropIndex("dbo.ProjectCharterQuestionPersistenceEntities", new[] { "Code" });
            DropIndex("dbo.ProjectCharterPersistenceEntities", new[] { "QuestionID" });
            DropIndex("dbo.ProjectCharterPersistenceEntities", new[] { "ProjectID" });
            DropIndex("dbo.ProjectCharterPersistenceEntities", new[] { "Code" });
            DropTable("dbo.StakeholderPersistenceEntities");
            DropTable("dbo.ProjectCharterQuestionHeaderPersistenceEntities");
            DropTable("dbo.ProjectCharterQuestionPersistenceEntities");
            DropTable("dbo.ProjectCharterPersistenceEntities");
        }
    }
}
