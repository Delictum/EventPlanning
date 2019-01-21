namespace EventPlanning.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateEventEmployeesContext : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.EventEmployee", name: "Event_EventId", newName: "EventId");
            RenameColumn(table: "dbo.EventEmployee", name: "Employee_EmployeeId", newName: "EmployeeId");
            RenameIndex(table: "dbo.EventEmployee", name: "IX_Event_EventId", newName: "IX_EventId");
            RenameIndex(table: "dbo.EventEmployee", name: "IX_Employee_EmployeeId", newName: "IX_EmployeeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.EventEmployee", name: "IX_EmployeeId", newName: "IX_Employee_EmployeeId");
            RenameIndex(table: "dbo.EventEmployee", name: "IX_EventId", newName: "IX_Event_EventId");
            RenameColumn(table: "dbo.EventEmployee", name: "EmployeeId", newName: "Employee_EmployeeId");
            RenameColumn(table: "dbo.EventEmployee", name: "EventId", newName: "Event_EventId");
        }
    }
}
