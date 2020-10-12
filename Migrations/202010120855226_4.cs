namespace EFExampleBasic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Students", "DateOfBirth", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            CreateIndex("dbo.Students", new[] { "FirstName", "LastName", "DateOfBirth" });
        }
        
        public override void Down()
        {
            DropIndex("dbo.Students", new[] { "FirstName", "LastName", "DateOfBirth" });
            AlterColumn("dbo.Students", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
        }
    }
}
