namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Status", "isClosing", c => c.Boolean(nullable: false));
            AddColumn("dbo.Status", "isOpen", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Status", "isOpen");
            DropColumn("dbo.Status", "isClosing");
        }
    }
}
