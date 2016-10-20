namespace MEAB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UnitTypes", "Unit_Id", "dbo.Units");
            DropIndex("dbo.UnitTypes", new[] { "Unit_Id" });
            AddColumn("dbo.Units", "UnitTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Units", "UnitTypeId");
            AddForeignKey("dbo.Units", "UnitTypeId", "dbo.UnitTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.UnitTypes", "Unit_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UnitTypes", "Unit_Id", c => c.Int());
            DropForeignKey("dbo.Units", "UnitTypeId", "dbo.UnitTypes");
            DropIndex("dbo.Units", new[] { "UnitTypeId" });
            DropColumn("dbo.Units", "UnitTypeId");
            CreateIndex("dbo.UnitTypes", "Unit_Id");
            AddForeignKey("dbo.UnitTypes", "Unit_Id", "dbo.Units", "Id");
        }
    }
}
