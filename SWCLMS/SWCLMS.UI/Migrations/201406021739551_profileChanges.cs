namespace SWCLMS.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profileChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable:false, maxLength: 25));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.AspNetUsers", "SuggestedAccount", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.AspNetUsers", "GradeLevel", c => c.Byte(nullable:true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "GradeLevel");
            DropColumn("dbo.AspNetUsers", "SuggestedAccount");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
