namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.APTs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.String(),
                        Counter = c.Int(nullable: false),
                        DbSuccess = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AlternativeNames",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Serial = c.Int(nullable: false),
                        Name = c.String(),
                        dbStatus = c.String(),
                        Status_Id = c.Int(),
                        APT_id = c.Int(),
                        APT_id1 = c.Int(),
                        APT_id2 = c.Int(),
                        APT_id3 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .ForeignKey("dbo.APTs", t => t.APT_id)
                .ForeignKey("dbo.APTs", t => t.APT_id1)
                .ForeignKey("dbo.APTs", t => t.APT_id2)
                .ForeignKey("dbo.APTs", t => t.APT_id3)
                .Index(t => t.Status_Id)
                .Index(t => t.APT_id)
                .Index(t => t.APT_id1)
                .Index(t => t.APT_id2)
                .Index(t => t.APT_id3);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusString = c.String(),
                        StatusTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StatusTypes", t => t.StatusTypeId, cascadeDelete: true)
                .Index(t => t.StatusTypeId);
            
            CreateTable(
                "dbo.AttachmentProps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Extension = c.String(),
                        Filename = c.String(),
                        Type = c.String(),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContentString = c.String(),
                        DbStatus = c.String(),
                        CreatedBy = c.String(),
                        createdDate = c.DateTime(nullable: false),
                        APT_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.APTs", t => t.APT_id)
                .Index(t => t.APT_id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        Contenant = c.String(),
                        dbStatus = c.String(),
                        Status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Status", t => t.Status_Id)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.ThreatSignatures",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Serial = c.Int(nullable: false),
                        Name = c.String(),
                        DomainName = c.String(),
                        dbStatus = c.String(),
                        APT_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.APTs", t => t.APT_id)
                .Index(t => t.APT_id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        code = c.String(),
                        label = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        commentString = c.String(),
                        Tasks_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Tasks", t => t.Tasks_id)
                .Index(t => t.Tasks_id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        SectionID = c.Int(nullable: false),
                        eid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Sections", t => t.SectionID, cascadeDelete: true)
                .Index(t => t.SectionID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        Employee_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Employees", t => t.Employee_id)
                .Index(t => t.Employee_id);
            
            CreateTable(
                "dbo.Incidents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        date = c.String(),
                        description = c.String(),
                        subject = c.String(),
                        time = c.String(),
                        category_id = c.Int(),
                        org_id = c.Int(),
                        saverity_id = c.Int(),
                        status_Id = c.Int(),
                        Urgancey_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Categories", t => t.category_id)
                .ForeignKey("dbo.Organizations", t => t.org_id)
                .ForeignKey("dbo.Saverities", t => t.saverity_id)
                .ForeignKey("dbo.Status", t => t.status_Id)
                .ForeignKey("dbo.Urganceys", t => t.Urgancey_id)
                .Index(t => t.category_id)
                .Index(t => t.org_id)
                .Index(t => t.saverity_id)
                .Index(t => t.status_Id)
                .Index(t => t.Urgancey_id);
            
            CreateTable(
                "dbo.IpAddresses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ip = c.String(),
                        Incident_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Incidents", t => t.Incident_id)
                .Index(t => t.Incident_id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        orgname = c.String(),
                        SectorId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Sectors", t => t.SectorId)
                .Index(t => t.SectorId);
            
            CreateTable(
                "dbo.Saverities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        code = c.String(),
                        lable = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Urganceys",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        code = c.String(),
                        label = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(),
                        createdBy = c.String(),
                        createdDate = c.DateTime(nullable: false),
                        title = c.String(),
                        importance = c.Int(nullable: false),
                        urgent = c.Int(nullable: false),
                        weights = c.Int(nullable: false),
                        actions = c.String(),
                        date = c.String(),
                        dueDate = c.String(),
                        assigned_for_id = c.Int(),
                        parentIncident_id = c.Int(),
                        parentTask_id = c.Int(),
                        status_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Sections", t => t.assigned_for_id)
                .ForeignKey("dbo.Incidents", t => t.parentIncident_id)
                .ForeignKey("dbo.Tasks", t => t.parentTask_id)
                .ForeignKey("dbo.Status", t => t.status_Id)
                .Index(t => t.assigned_for_id)
                .Index(t => t.parentIncident_id)
                .Index(t => t.parentTask_id)
                .Index(t => t.status_Id);
            
            CreateTable(
                "dbo.Sectors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.StatusTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        statusType = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.AptAttachments",
                c => new
                    {
                        APT_id = c.Int(nullable: false),
                        AttachmentProp_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.APT_id, t.AttachmentProp_Id })
                .ForeignKey("dbo.APTs", t => t.APT_id, cascadeDelete: true)
                .ForeignKey("dbo.AttachmentProps", t => t.AttachmentProp_Id, cascadeDelete: true)
                .Index(t => t.APT_id)
                .Index(t => t.AttachmentProp_Id);
            
            CreateTable(
                "dbo.OriginCountries",
                c => new
                    {
                        Country_Id = c.Int(nullable: false),
                        APT_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Country_Id, t.APT_id })
                .ForeignKey("dbo.Countries", t => t.Country_Id, cascadeDelete: true)
                .ForeignKey("dbo.APTs", t => t.APT_id, cascadeDelete: true)
                .Index(t => t.Country_Id)
                .Index(t => t.APT_id);
            
            CreateTable(
                "dbo.TargetedCountries",
                c => new
                    {
                        Country_Id = c.Int(nullable: false),
                        APT_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Country_Id, t.APT_id })
                .ForeignKey("dbo.Countries", t => t.Country_Id, cascadeDelete: true)
                .ForeignKey("dbo.APTs", t => t.APT_id, cascadeDelete: true)
                .Index(t => t.Country_Id)
                .Index(t => t.APT_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Status", "StatusTypeId", "dbo.StatusTypes");
            DropForeignKey("dbo.Organizations", "SectorId", "dbo.Sectors");
            DropForeignKey("dbo.Tasks", "status_Id", "dbo.Status");
            DropForeignKey("dbo.Tasks", "parentTask_id", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "parentIncident_id", "dbo.Incidents");
            DropForeignKey("dbo.Comments", "Tasks_id", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "assigned_for_id", "dbo.Sections");
            DropForeignKey("dbo.Employees", "SectionID", "dbo.Sections");
            DropForeignKey("dbo.Incidents", "Urgancey_id", "dbo.Urganceys");
            DropForeignKey("dbo.Incidents", "status_Id", "dbo.Status");
            DropForeignKey("dbo.Incidents", "saverity_id", "dbo.Saverities");
            DropForeignKey("dbo.Incidents", "org_id", "dbo.Organizations");
            DropForeignKey("dbo.IpAddresses", "Incident_id", "dbo.Incidents");
            DropForeignKey("dbo.Incidents", "category_id", "dbo.Categories");
            DropForeignKey("dbo.Roles", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.AlternativeNames", "APT_id3", "dbo.APTs");
            DropForeignKey("dbo.ThreatSignatures", "APT_id", "dbo.APTs");
            DropForeignKey("dbo.AlternativeNames", "APT_id2", "dbo.APTs");
            DropForeignKey("dbo.TargetedCountries", "APT_id", "dbo.APTs");
            DropForeignKey("dbo.TargetedCountries", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Countries", "Status_Id", "dbo.Status");
            DropForeignKey("dbo.OriginCountries", "APT_id", "dbo.APTs");
            DropForeignKey("dbo.OriginCountries", "Country_Id", "dbo.Countries");
            DropForeignKey("dbo.Contents", "APT_id", "dbo.APTs");
            DropForeignKey("dbo.AlternativeNames", "APT_id1", "dbo.APTs");
            DropForeignKey("dbo.AptAttachments", "AttachmentProp_Id", "dbo.AttachmentProps");
            DropForeignKey("dbo.AptAttachments", "APT_id", "dbo.APTs");
            DropForeignKey("dbo.AlternativeNames", "APT_id", "dbo.APTs");
            DropForeignKey("dbo.AlternativeNames", "Status_Id", "dbo.Status");
            DropIndex("dbo.TargetedCountries", new[] { "APT_id" });
            DropIndex("dbo.TargetedCountries", new[] { "Country_Id" });
            DropIndex("dbo.OriginCountries", new[] { "APT_id" });
            DropIndex("dbo.OriginCountries", new[] { "Country_Id" });
            DropIndex("dbo.AptAttachments", new[] { "AttachmentProp_Id" });
            DropIndex("dbo.AptAttachments", new[] { "APT_id" });
            DropIndex("dbo.Tasks", new[] { "status_Id" });
            DropIndex("dbo.Tasks", new[] { "parentTask_id" });
            DropIndex("dbo.Tasks", new[] { "parentIncident_id" });
            DropIndex("dbo.Tasks", new[] { "assigned_for_id" });
            DropIndex("dbo.Organizations", new[] { "SectorId" });
            DropIndex("dbo.IpAddresses", new[] { "Incident_id" });
            DropIndex("dbo.Incidents", new[] { "Urgancey_id" });
            DropIndex("dbo.Incidents", new[] { "status_Id" });
            DropIndex("dbo.Incidents", new[] { "saverity_id" });
            DropIndex("dbo.Incidents", new[] { "org_id" });
            DropIndex("dbo.Incidents", new[] { "category_id" });
            DropIndex("dbo.Roles", new[] { "Employee_id" });
            DropIndex("dbo.Employees", new[] { "SectionID" });
            DropIndex("dbo.Comments", new[] { "Tasks_id" });
            DropIndex("dbo.ThreatSignatures", new[] { "APT_id" });
            DropIndex("dbo.Countries", new[] { "Status_Id" });
            DropIndex("dbo.Contents", new[] { "APT_id" });
            DropIndex("dbo.Status", new[] { "StatusTypeId" });
            DropIndex("dbo.AlternativeNames", new[] { "APT_id3" });
            DropIndex("dbo.AlternativeNames", new[] { "APT_id2" });
            DropIndex("dbo.AlternativeNames", new[] { "APT_id1" });
            DropIndex("dbo.AlternativeNames", new[] { "APT_id" });
            DropIndex("dbo.AlternativeNames", new[] { "Status_Id" });
            DropTable("dbo.TargetedCountries");
            DropTable("dbo.OriginCountries");
            DropTable("dbo.AptAttachments");
            DropTable("dbo.StatusTypes");
            DropTable("dbo.Sectors");
            DropTable("dbo.Tasks");
            DropTable("dbo.Sections");
            DropTable("dbo.Urganceys");
            DropTable("dbo.Saverities");
            DropTable("dbo.Organizations");
            DropTable("dbo.IpAddresses");
            DropTable("dbo.Incidents");
            DropTable("dbo.Roles");
            DropTable("dbo.Employees");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.ThreatSignatures");
            DropTable("dbo.Countries");
            DropTable("dbo.Contents");
            DropTable("dbo.AttachmentProps");
            DropTable("dbo.Status");
            DropTable("dbo.AlternativeNames");
            DropTable("dbo.APTs");
        }
    }
}
