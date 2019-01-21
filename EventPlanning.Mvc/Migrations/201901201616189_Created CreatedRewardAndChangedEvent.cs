namespace EventPlanning.Mvc.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreatedCreatedRewardAndChangedEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventDescription", c => c.String());
            AddColumn("dbo.Events", "EventImage", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventImage");
            DropColumn("dbo.Events", "EventDescription");
        }
    }
}
