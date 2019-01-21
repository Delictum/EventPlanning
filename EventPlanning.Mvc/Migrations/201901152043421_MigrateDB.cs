namespace EventPlanning.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Birthday = c.DateTime(nullable: false),
                        BiologicalFloor = c.Int(nullable: false),
                        Adress = c.String(),
                        FullName_FullNameId = c.Int(),
                        Group_GroupId = c.Int(),
                        Position_PositionId = c.Int(),
                        Event_EventId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.FullNames", t => t.FullName_FullNameId)
                .ForeignKey("dbo.Groups", t => t.Group_GroupId)
                .ForeignKey("dbo.Positions", t => t.Position_PositionId)
                .ForeignKey("dbo.Events", t => t.Event_EventId)
                .Index(t => t.FullName_FullNameId)
                .Index(t => t.Group_GroupId)
                .Index(t => t.Position_PositionId)
                .Index(t => t.Event_EventId);
            
            CreateTable(
                "dbo.FullNames",
                c => new
                    {
                        FullNameId = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        SureName = c.String(),
                    })
                .PrimaryKey(t => t.FullNameId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                    })
                .PrimaryKey(t => t.PositionId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventTitle = c.String(),
                        EventDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Event_EventId", "dbo.Events");
            DropForeignKey("dbo.Employees", "Position_PositionId", "dbo.Positions");
            DropForeignKey("dbo.Employees", "Group_GroupId", "dbo.Groups");
            DropForeignKey("dbo.Employees", "FullName_FullNameId", "dbo.FullNames");
            DropIndex("dbo.Employees", new[] { "Event_EventId" });
            DropIndex("dbo.Employees", new[] { "Position_PositionId" });
            DropIndex("dbo.Employees", new[] { "Group_GroupId" });
            DropIndex("dbo.Employees", new[] { "FullName_FullNameId" });
            DropTable("dbo.Events");
            DropTable("dbo.Positions");
            DropTable("dbo.Groups");
            DropTable("dbo.FullNames");
            DropTable("dbo.Employees");
        }
    }
}
