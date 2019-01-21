namespace EventPlanning.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedReward : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventRewards",
                c => new
                    {
                        EventRewardId = c.Int(nullable: false, identity: true),
                        AmountRewards = c.Double(nullable: false),
                        EventId = c.Int(nullable: false),
                        RewardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventRewardId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Rewards", t => t.RewardId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.RewardId);
            
            CreateTable(
                "dbo.Rewards",
                c => new
                    {
                        RewardId = c.Int(nullable: false, identity: true),
                        AwardName = c.String(),
                    })
                .PrimaryKey(t => t.RewardId);
            
            CreateTable(
                "dbo.IssuedRewards",
                c => new
                    {
                        IssuedRewardId = c.Int(nullable: false, identity: true),
                        RemunerationDate = c.DateTime(nullable: false),
                        AmountRewardIssued = c.Double(nullable: false),
                        EventRewardId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IssuedRewardId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.EventRewards", t => t.EventRewardId, cascadeDelete: true)
                .Index(t => t.EventRewardId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IssuedRewards", "EventRewardId", "dbo.EventRewards");
            DropForeignKey("dbo.IssuedRewards", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EventRewards", "RewardId", "dbo.Rewards");
            DropForeignKey("dbo.EventRewards", "EventId", "dbo.Events");
            DropIndex("dbo.IssuedRewards", new[] { "EmployeeId" });
            DropIndex("dbo.IssuedRewards", new[] { "EventRewardId" });
            DropIndex("dbo.EventRewards", new[] { "RewardId" });
            DropIndex("dbo.EventRewards", new[] { "EventId" });
            DropTable("dbo.IssuedRewards");
            DropTable("dbo.Rewards");
            DropTable("dbo.EventRewards");
        }
    }
}
