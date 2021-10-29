namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class closingReport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CloseReports",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        report = c.String(),
                        closedBy = c.Int(nullable: false),
                        closingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CloseReportAttachmentProps",
                c => new
                    {
                        CloseReport_id = c.Int(nullable: false),
                        AttachmentProp_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CloseReport_id, t.AttachmentProp_Id })
                .ForeignKey("dbo.CloseReports", t => t.CloseReport_id, cascadeDelete: true)
                .ForeignKey("dbo.AttachmentProps", t => t.AttachmentProp_Id, cascadeDelete: true)
                .Index(t => t.CloseReport_id)
                .Index(t => t.AttachmentProp_Id);
            
            AddColumn("dbo.Tasks", "closingReport_id", c => c.Int());
            CreateIndex("dbo.Tasks", "closingReport_id");
            AddForeignKey("dbo.Tasks", "closingReport_id", "dbo.CloseReports", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "closingReport_id", "dbo.CloseReports");
            DropForeignKey("dbo.CloseReportAttachmentProps", "AttachmentProp_Id", "dbo.AttachmentProps");
            DropForeignKey("dbo.CloseReportAttachmentProps", "CloseReport_id", "dbo.CloseReports");
            DropIndex("dbo.CloseReportAttachmentProps", new[] { "AttachmentProp_Id" });
            DropIndex("dbo.CloseReportAttachmentProps", new[] { "CloseReport_id" });
            DropIndex("dbo.Tasks", new[] { "closingReport_id" });
            DropColumn("dbo.Tasks", "closingReport_id");
            DropTable("dbo.CloseReportAttachmentProps");
            DropTable("dbo.CloseReports");
        }
    }
}
