namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtaskowner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "taskOwner", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "taskOwner");
        }
    }
}
