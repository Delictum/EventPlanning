namespace EventPlanning.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedEventRewards : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventRewards", "IssuanceOnRequest", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventRewards", "IssuanceOnRequest");
        }
    }
}
