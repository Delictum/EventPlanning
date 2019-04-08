namespace EventPlanning.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "SplitNumberGroups", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "SplitNumberParticipants", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "EventCategory", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventCategory");
            DropColumn("dbo.Events", "SplitNumberParticipants");
            DropColumn("dbo.Events", "SplitNumberGroups");
        }
    }
}
