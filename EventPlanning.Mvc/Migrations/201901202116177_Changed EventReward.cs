namespace EventPlanning.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedEventReward : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventRewards", "WriteOffInQuantity", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventRewards", "WriteOffInQuantity");
        }
    }
}
