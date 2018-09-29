namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedTrailConditionToEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trail", "TrailCondition", c => c.Int(nullable: false));
            DropColumn("dbo.Trail", "IsOpen");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trail", "IsOpen", c => c.Boolean(nullable: false));
            DropColumn("dbo.Trail", "TrailCondition");
        }
    }
}
