namespace EventPlanning.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateEventEmployees : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EventEmployees", newName: "EventEmployee");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.EventEmployee", newName: "EventEmployees");
        }
    }
}
