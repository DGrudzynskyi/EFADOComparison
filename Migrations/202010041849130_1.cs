namespace EFExampleBasic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudyClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartYear = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.String(),
                        Address_City = c.String(),
                        Address_FirstLine = c.String(),
                        Address_SecondLine = c.String(),
                        StudyClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudyClasses", t => t.StudyClassId, cascadeDelete: true)
                .Index(t => t.StudyClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StudyClassId", "dbo.StudyClasses");
            DropIndex("dbo.Students", new[] { "StudyClassId" });
            DropTable("dbo.Students");
            DropTable("dbo.StudyClasses");
        }
    }
}
