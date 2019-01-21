namespace EventPlanning.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedVisibleforEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventVisible", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventVisible");
        }
    }
}
