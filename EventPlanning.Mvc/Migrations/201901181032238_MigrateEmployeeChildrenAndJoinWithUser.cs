namespace EventPlanning.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateEmployeeChildrenAndJoinWithUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "AspNetUsersId", c => c.String());
            AddColumn("dbo.Employees", "AmountChildren", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "AmountChildren");
            DropColumn("dbo.Employees", "AspNetUsersId");
        }
    }
}
