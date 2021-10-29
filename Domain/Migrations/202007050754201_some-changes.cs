namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somechanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "commentDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "commentedBy_id", c => c.Int());
            AddColumn("dbo.Tasks", "progress", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "rate", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "commentedBy_id");
            AddForeignKey("dbo.Comments", "commentedBy_id", "dbo.Employees", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "commentedBy_id", "dbo.Employees");
            DropIndex("dbo.Comments", new[] { "commentedBy_id" });
            DropColumn("dbo.Tasks", "rate");
            DropColumn("dbo.Tasks", "progress");
            DropColumn("dbo.Comments", "commentedBy_id");
            DropColumn("dbo.Comments", "commentDate");
        }
    }
}
