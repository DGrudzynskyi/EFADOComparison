namespace EFExampleBasic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "IsLiveInDormitory", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Students", "DateOfBirth", c => c.DateTime(nullable: true));

            Sql("update dbo.Students set DateOfBirth = '12/31/2008 09:01:01'");
            AlterColumn("dbo.Students", "DateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "DateOfBirth", c => c.String());
            DropColumn("dbo.Students", "IsLiveInDormitory");
        }
    }
}
