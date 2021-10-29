namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sssss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TasksEmployees",
                c => new
                    {
                        Tasks_id = c.Int(nullable: false),
                        Employee_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tasks_id, t.Employee_id })
                .ForeignKey("dbo.Tasks", t => t.Tasks_id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_id, cascadeDelete: true)
                .Index(t => t.Tasks_id)
                .Index(t => t.Employee_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TasksEmployees", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.TasksEmployees", "Tasks_id", "dbo.Tasks");
            DropIndex("dbo.TasksEmployees", new[] { "Employee_id" });
            DropIndex("dbo.TasksEmployees", new[] { "Tasks_id" });
            DropTable("dbo.TasksEmployees");
        }
    }
}
