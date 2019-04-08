namespace EventPlanning.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaxparticipantsinevents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "MaximumNumberParticipants", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "MaximumNumberParticipants");
        }
    }
}
