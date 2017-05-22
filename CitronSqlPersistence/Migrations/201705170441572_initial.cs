namespace CitronSqlPersistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeePersistenceEntities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Photo = c.String(),
                        Birthday = c.String(),
                        MaritalStatus = c.Int(nullable: false),
                        PersonalityType = c.Int(nullable: false),
                        BloodGroup = c.Int(nullable: false),
                        CitizenshipNo = c.String(),
                        EmailId = c.String(),
                        LocalAddress = c.String(),
                        LocalAddressContactNo = c.String(),
                        PermanentAddress = c.String(),
                        PermanentAddressContactNo = c.String(),
                        EmergencyAddress = c.String(),
                        EmergencyAddressContactNo = c.String(),
                        GooglePlusLink = c.String(),
                        FacebookLink = c.String(),
                        TwitterLink = c.String(),
                        LinkedInLink = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeePersistenceEntities");
        }
    }
}
