namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedParkName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trail", "ParkName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trail", "ParkName");
        }
    }
}
