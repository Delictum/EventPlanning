namespace EventPlanning.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Event_EventId", "dbo.Events");
            DropIndex("dbo.Employees", new[] { "Event_EventId" });
            CreateTable(
                "dbo.EventEmployees",
                c => new
                    {
                        Event_EventId = c.Int(nullable: false),
                        Employee_EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_EventId, t.Employee_EmployeeId })
                .ForeignKey("dbo.Events", t => t.Event_EventId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .Index(t => t.Event_EventId)
                .Index(t => t.Employee_EmployeeId);
            
            DropColumn("dbo.Employees", "Event_EventId");
            DropColumn("dbo.Events", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Event_EventId", c => c.Int());
            DropForeignKey("dbo.EventEmployees", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EventEmployees", "Event_EventId", "dbo.Events");
            DropIndex("dbo.EventEmployees", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.EventEmployees", new[] { "Event_EventId" });
            DropTable("dbo.EventEmployees");
            CreateIndex("dbo.Employees", "Event_EventId");
            AddForeignKey("dbo.Employees", "Event_EventId", "dbo.Events", "EventId");
        }
    }
}
