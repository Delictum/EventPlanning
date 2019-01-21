namespace EventPlanning.Mvc.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreatedRepeatEventType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "RepeatEventType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "RepeatEventType");
        }
    }
}
