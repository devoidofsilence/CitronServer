namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNotefieldinProjectCharterQuestions : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectCharterQuestionPersistenceEntities", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectCharterQuestionPersistenceEntities", "Note");
        }
    }
}
