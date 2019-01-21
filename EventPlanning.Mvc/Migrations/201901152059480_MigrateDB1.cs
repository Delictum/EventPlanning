namespace EventPlanning.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "FullName_FullNameId", "dbo.FullNames");
            DropForeignKey("dbo.Employees", "Group_GroupId", "dbo.Groups");
            DropForeignKey("dbo.Employees", "Position_PositionId", "dbo.Positions");
            DropIndex("dbo.Employees", new[] { "FullName_FullNameId" });
            DropIndex("dbo.Employees", new[] { "Group_GroupId" });
            DropIndex("dbo.Employees", new[] { "Position_PositionId" });
            RenameColumn(table: "dbo.Employees", name: "FullName_FullNameId", newName: "FullNameId");
            RenameColumn(table: "dbo.Employees", name: "Group_GroupId", newName: "GroupId");
            RenameColumn(table: "dbo.Employees", name: "Position_PositionId", newName: "PositionId");
            AddColumn("dbo.Events", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "FullNameId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "GroupId", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "PositionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "FullNameId");
            CreateIndex("dbo.Employees", "PositionId");
            CreateIndex("dbo.Employees", "GroupId");
            AddForeignKey("dbo.Employees", "FullNameId", "dbo.FullNames", "FullNameId", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "GroupId", "dbo.Groups", "GroupId", cascadeDelete: true);
            AddForeignKey("dbo.Employees", "PositionId", "dbo.Positions", "PositionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Employees", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Employees", "FullNameId", "dbo.FullNames");
            DropIndex("dbo.Employees", new[] { "GroupId" });
            DropIndex("dbo.Employees", new[] { "PositionId" });
            DropIndex("dbo.Employees", new[] { "FullNameId" });
            AlterColumn("dbo.Employees", "PositionId", c => c.Int());
            AlterColumn("dbo.Employees", "GroupId", c => c.Int());
            AlterColumn("dbo.Employees", "FullNameId", c => c.Int());
            DropColumn("dbo.Events", "EmployeeId");
            RenameColumn(table: "dbo.Employees", name: "PositionId", newName: "Position_PositionId");
            RenameColumn(table: "dbo.Employees", name: "GroupId", newName: "Group_GroupId");
            RenameColumn(table: "dbo.Employees", name: "FullNameId", newName: "FullName_FullNameId");
            CreateIndex("dbo.Employees", "Position_PositionId");
            CreateIndex("dbo.Employees", "Group_GroupId");
            CreateIndex("dbo.Employees", "FullName_FullNameId");
            AddForeignKey("dbo.Employees", "Position_PositionId", "dbo.Positions", "PositionId");
            AddForeignKey("dbo.Employees", "Group_GroupId", "dbo.Groups", "GroupId");
            AddForeignKey("dbo.Employees", "FullName_FullNameId", "dbo.FullNames", "FullNameId");
        }
    }
}
